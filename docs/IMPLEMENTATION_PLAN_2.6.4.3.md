# Implementation Plan: SWAMY 2.6.4.3 (wrong-gas, duplicate SN, password lockout)

Status: **PLAN APPROVED IN REVIEW (8 Nov 2026) - waiting for Greg's go-ahead before coding.** Design decisions D1-D5 are recorded in section 3.

- Branch: work and commit on `feature/wronggas-duplicate-lockout`. Merge into `Version_2_6_4_0` only after Greg's bench test passes.
- Source of truth: Claude Doc "SWAMY Sorter Disposition Requirements & Pass/Fail Criteria" (https://claude.ai/artifact/6YKR3ZdereADxeyRCirUjV). The requirements and tests in scope are copied below so this file stands alone.
- Background: protocol PVP-102-014-042 Rev C (IOPQ) and the review doc "SWAMY IOPQ Protocol Review" (https://claude.ai/artifact/BvUyBWFZ8ZarSv8tDdFdQp), findings F1-F15.
- Decisions on open questions came from Andrew Hill (protocol originator), 8 Nov 2026. Design decisions D1-D5 from Greg's plan review, 8 Nov 2026.

## 0. Starting state (check before anything else)

- Commit `2fa3ea4` ("baseline on updates") holds the Form1.vb line 279 units fix (TareLimit mg -> g) and the new `RELEASE_NOTES.md`. Greg has bench-checked that build; it is the baseline for this change set.
- Commit `292ac3e` (20 Oct 2026) holds the sort-timeout and wrong-gas fixes (SR-01 to SR-09). Last publish was 2.6.4.2. `ApplicationRevision` is already 3, so the next publish is 2.6.4.3. Do not change version settings and do not publish.
- The existing 2.6.4.3 wrong-gas bullet in `RELEASE_NOTES.md` says the cylinder is "not weighed, recorded or counted". SR-08 now requires a log line and a bad count, so that bullet must be rewritten.

## 1. Requirements in scope

| ID | Requirement (summary; the Claude Doc has the full wording) |
| --- | --- |
| SR-06 | A SN already in the current bag still raises the duplicate SN error; handled per SR-11 and SR-12. |
| SR-07 | Wrong-gas SN (first digit not 1 = SF6 / 2 = C3F8 for the lot): show "Incorrect Serial Number. Halt Production to Investigate" and red HALT on the labels, open the bad chute, and **wait up to 15 s for the drop**. No pop-up during the wait; the pop-up comes after the drop or the timeout, before the password prompt. No sorter attached: no wait, treated as dropped. |
| SR-08 | On a detected drop: write a data file line (SN, "Wrong Gas") and **add 1 to the bad count**; then supervisor password (SR-14), close chute, clear SN field, return to Scan. Not weighed. |
| SR-10 | Wrong gas, no drop within 15 s: close chute, show "Wrong gas cylinder not in bad bin", password (SR-14). Write line (SN, "Wrong Gas - Not Sorted"); **do not** add to the bad count. |
| SR-11 | Duplicate SN (first-weight and post-weigh): show the duplicate error, open the bad chute, wait up to 15 s. On drop: write a line for the duplicate scan (SN, "Duplicate SN") in scan order, bad count +1, password (SR-14), close chute, return to Scan. Not weighed. No drop: as SR-10 with "Duplicate SN - Not Sorted" and the message "Duplicate SN cylinder not in bad bin". |
| SR-12 | The **first instance** of a duplicated SN is also marked "Duplicate SN" in the data file, in both modes. In first-weight mode the first instance is rejected at post-weigh. Counts are not changed and SWAMY gives no instruction to move the part (file mark only; NCR handles it). In post-weigh mode the mark is an appended line "Duplicate SN - First Instance" (D2). |
| SR-13 | Lines written under SR-08, SR-10, SR-11 do not count toward the parts expected at post-weigh and are not read as first weights, so the post-weigh bag still closes on its own after the last real part. Event and "Duplicate SN - First Instance" marker lines are excluded from the post-weigh resume count. A first-weight file with no part lines loads without a crash (empty-file guard). |
| SR-14 | Every supervisor password prompt (sort timeout, wrong gas, duplicate) behaves as SR-03: 6 attempts, attempts remaining shown after each wrong entry, on the 6th "Incorrect password entered 6 times. The bag will be closed." and the bag closes. Cancel or blank counts as a wrong entry. |

Unchanged and must keep working: SR-01 to SR-05 (sort timeout), SR-09 (empty SN).

## 2. Findings from the code review that shape the design

1. **A modal pop-up between opening the chute and `Dropped` can miss the drop.** The drop sensors only read true while the part passes. Today the wrong-gas code opens the chute and then shows a MsgBox (`Form1.vb` ~line 1088). If the part is dropped while the MsgBox is open, `Dropped` starts polling only after OK and reports "not sorted". So nothing modal is shown between `Sort(2)` and `Dropped`; messages go on labels, with `Me.Refresh()` first because `Dropped` blocks the UI thread.
2. **`Readfirstweight` sizes its array from the first line's column count.** A file with mixed 2- and 3-column lines throws IndexOutOfRange. The reader must use a fixed column count and pad.
3. **The duplicate-scan line and the first instance both say "Duplicate SN".** Event lines are told apart from part lines by a **blank weight column**. Real part lines always have a weight; 2.6.4.2 files never have a blank weight.

## 3. Design decisions (approved 8 Nov 2026)

- **D1. Data model.** One list per bag in scan order (`CylinderList`). `Cylinder` gets `IsEvent As Boolean` and `Status As String`. Event records carry their text in `Status`. In first-weight mode, events are added to `CylinderList` so they are written in scan order at bag close. In post-weigh mode, events are written to the Completed file straight away and are not added to the list. `SN_Already_Exists` ignores event records. `PalletComplete` is unchanged: it uses `CountGood` (first weight) and `canisternumber` (post-weigh), and events change neither.
- **D2. First instance in post-weigh: Option B, append-only.** A recorded line is never rewritten. When a duplicate is detected, before the chute opens, append `<SN>, , , , , Duplicate SN - First Instance` (blank weights and blank Disposition, so the first instance is not counted twice by anyone totalling the Disposition column). The duplicate-scan line follows (`<SN>, , , , False, Duplicate SN` or `... - Not Sorted`). The marker is written once per SN; a third scan gets its own duplicate-scan line but no second marker (the first instance's in-memory `Status` records that it is already marked). The resume count skips both lines through the blank-weight rule.
- **D3. Backward compatibility.** First-weight file writer: normal part lines are unchanged (`SN, wt`); the first instance of a duplicate is `SN, wt, Duplicate SN`; event lines are `SN, , <event text>`. Reader: skip lines whose weight column is blank after trimming (not counted in `number_of_Canisters`), fixed 3 columns, pad missing columns with "", trim the status. 2.6.4.2 files with `-20` still go through the existing "Incorrect Serial Number" path. `All02Wt2nd_Pass` reads column 2 but has no callers; leave it alone.
- **D4. Lockout inside `SN_Validating`.** Keep the wrong-gas handling in the Validating event, but run it **only when `teststate = Weighprocess.Scanning`**. `SN_Validating` fires on any focus loss from the SN box to a control that causes validation (for example clicking Stop Bag while a wrong-gas SN is in the box during taring or weighing). Outside Scanning, a wrong-gas SN keeps today's generic handling (ErrorProvider "Wrong Gas Type", `e.Cancel = True`) and does not open the chute, log, count or prompt. Stop `Tmr_ScreenUpdate` on entry (modal dialogs pump messages, so the timer would otherwise keep ticking). Keep `e.Cancel = True` so `Validated` never fires and `scanned` stays False. On lockout: clear the SN field, call `Closepallet()` (it sets `CausesValidation = False` and goes to idle), exit. On success: close the chute, clear the SN field and the ErrorProvider, show "Scan", restart the timer.
- **D5. UI freeze.** Accept the existing `CSorter.Dropped` busy-wait (up to 15 s), as for normal sorts. Only add `Me.Refresh()` before it. **No sorter attached:** skip the drop wait and treat the part as dropped (log the event, bad count +1), matching normal sorts without a sorter. The IOPQ always runs with the sorter attached; F12 already recommends recording the Sorter Attached setting in Att. 9.

### Event sequence (wrong gas and duplicate)

1. Show HALT (wrong gas) or the duplicate error on the labels (red), set the ErrorProvider, `Me.Refresh()`. Duplicate in post-weigh only: append the first-instance marker line (D2) if not already written.
2. Open the bad chute (`Sort(2)`) and wait on `Dropped` (up to 15 s). No modal dialogs during the wait.
3. Dropped: log `<reason>`, bad count +1. Not dropped: close the chute (`Sort(255)`), log `<reason> - Not Sorted`, bad count unchanged. Logging happens before any dialog. In post-weigh mode the line is written to the file at once, so a lockout or crash still leaves it. In first-weight mode the line is held in `CylinderList` and written at bag close (as today for all first-weight lines): a lockout still records it because the lockout closes the bag, but a crash before bag close loses it.
4. One critical-icon pop-up (the "stop and acknowledge" moment):

   | Case | Pop-up text |
   | --- | --- |
   | Wrong gas, dropped | "Incorrect Serial Number. Halt Production to Investigate" + SN |
   | Wrong gas, not dropped | Same + "Wrong gas cylinder not in bad bin" |
   | Duplicate, dropped | Duplicate error + SN |
   | Duplicate, not dropped | Same + "Duplicate SN cylinder not in bad bin" |

5. Supervisor password (SR-14). On lockout the bag closes; the event line is recorded (post-weigh: already in the file; first-weight: written by the bag close).
6. Close the chute, clear the SN field, return to Scan.

## 4. Code changes by file

### Constants (event texts)

Defined once as constants (in `Cylinder.vb`, shared by `Form1.vb` and `PalletData.vb`): "Wrong Gas", "Wrong Gas - Not Sorted", "Duplicate SN", "Duplicate SN - Not Sorted", "Duplicate SN - First Instance", "Wrong gas cylinder not in bad bin", "Duplicate SN cylinder not in bad bin". Existing message "Incorrect Serial Number. Halt Production to Investigate" stays a constant.

### Form1.vb

1. `Function RequireSupervisorPassword(title As String) As Boolean` (False = locked out). Reuses `MaxSupervisorAttempts = 6` and the existing messages; Cancel/blank counts as a wrong entry (SR-14). The sort-timeout loop in `Tmr_ScreenUpdate_Tick` (prompting, ~line 300) is switched to it with no behavior change (SR-03).
2. `Function HandleRejectedScan(sn, reason, popupText, notSortedText, title) As Boolean`, shared by wrong gas and duplicate; implements steps 2-6 of the event sequence. False = bag closed by lockout.
3. `Sub LogScanEvent(sn, text)`: first-weight mode -> `MDataset.AddEvent`; post-weigh -> append `SN, , , , False, <text>` to the Completed file at once.
4. `Sub CountEventAsBad()`: `MDataset.Numbad += 1`, `My.Settings.TotalBad += 1`, save, refresh labels. `Updatecounts` unchanged.
5. Wrong gas in `SN_Validating` (SR-07, SR-08, SR-10): only when `teststate = Weighprocess.Scanning` (D4); labels, then `HandleRejectedScan`, then reset as in D4. The existing MsgBox before the password is replaced by the post-wait pop-up.
6. Duplicate in the Scanning state (~line 203) (SR-06, SR-11, SR-12): stop the timer, labels, `MDataset.MarkDuplicate(sn)`; post-weigh: append the first-instance marker; then `HandleRejectedScan`. `entering` is already True (set at line 199 before the duplicate branch), so the Scan reset happens today; the code keeps that and does not need to set it again.
7. Post-weigh (~line 222): `ccylinder.Status = MDataset.FirstWeightStatus(sn)`.
8. `Write_Totals_FirstWT`: writes the three line formats in D3.

### PalletData.vb

- `SN_Already_Exists`: remove the `-20` overwrite (in post-weigh it also wrongly set the list copy's second weight); ignore event records.
- New: `MarkDuplicate(sn)` (sets the first instance's `Status` to "Duplicate SN"; returns whether it was already marked), `AddEvent(sn, text)`, `FirstWeightStatus(sn) As String` (does not increment `canisternumber`).
- `Readfirstweight`: D3 reader (SR-13), plus an **empty-file guard (SR-13)**: a file with no part lines (now possible, e.g. a bag with only event lines) must not crash; `number_of_Canisters` = 0 and lookups return the existing not-found values.
- `GetCurrentCount`: `datalines = (linecount - 5) - <lines with a blank "1st Wt" column>` (SR-13), keeping today's arithmetic otherwise.

### Cylinder.vb

- `IsEvent` and `Status` properties; event-text constants.
- `DetermineDisposition`: if `Status = "Duplicate SN"` -> reject, reason "Duplicate SN" (SR-12). Checked before the `-20` check, which stays for an SN missing from the first-weight file.

### RELEASE_NOTES.md

Rewrite the wrong-gas bullet; add bullets for SR-10, SR-11, SR-12, SR-13, SR-14, the first-weight and Completed file line formats, and the no-sorter behavior (D5), each with SR IDs.

## 5. Out of scope for this change set (do not fix without a separate decision)

Review-doc findings still open: F2 (post-weigh bag auto-close vs. Att. 14), F3 (timeout rescan counted twice in post-weigh via `Initialweight` incrementing `canisternumber`), F5 (Archived copy crash on rerun), F6 (ALL02 parsing has no error handling), F10-F15.

- F3 interaction: duplicate scans are handled before `Initialweight` is called, so they do not increment `canisternumber`; SR-13 does not make F3 worse.
- F15 (new): after resuming a post-weigh bag, `CylinderList` is empty, so a duplicate of a part weighed before the resume is not detected.

## 6. Verification

Build: `msbuild "Manual Scale Operation.sln"` (or Visual Studio). Requires the MCC DAQ (MccDaq) library on the machine. There are no automated tests; the scale and sorter are hardware, so tests are bench tests run by Greg.

Bench tests from the requirements doc (run T-01 to T-03, T-06, T-08, T-10 in both first-weight and post-weigh modes):

| Test | Pass criteria (summary) |
| --- | --- |
| T-01/T-02 Sort timeout good/bad | Unchanged (regression). |
| T-03 Duplicate SN | Duplicate error; bad chute opens; pop-up and password only after the drop; bad count +1, good unchanged; both instances marked in scan order ("Duplicate SN" in first-weight mode; "Duplicate SN - First Instance" marker in post-weigh). |
| T-04 Normal sort | Unchanged (regression). |
| T-05 Timeout lockout | Unchanged (regression). |
| T-06 Wrong gas, dropped | HALT on labels during the wait; bad chute opens; pop-up and password only after the drop; bad count +1; one "Wrong Gas" line; not weighed. |
| T-07 Empty SN | Unchanged (regression). |
| T-08 Wrong gas, not dropped | Chute closes after 15 s; "not in bad bin" pop-up; password; bad count unchanged; one "Wrong Gas - Not Sorted" line. |
| T-09 Duplicate first weight -> post-weigh | First-weight file marks both; first instance rejected at post-weigh with reason "Duplicate SN". |
| T-10 Duplicate, not dropped | As T-08 with "Duplicate SN - Not Sorted" and "Duplicate SN cylinder not in bad bin"; first instance still marked. |
| T-11 Post-weigh close with logged lines | Bag closes on its own after the last real part; nothing left unprocessed. |
| T-12 Lockout at wrong-gas and duplicate prompts | Same as T-05 at both; Cancel counts as a wrong entry; the event line is still in the file. |
| T-13 File handling | All T-13 checks below pass. |

T-13 file-handling checks:

- T-13a: A 2.6.4.2 first-weight file containing `-20` loads in post-weigh; that part is rejected "Incorrect Serial Number".
- T-13b: Resuming a Completed file that contains event and marker lines gives the correct part count.
- T-13c: An In Process first-weight file opened and saved in Excel still loads (Excel may pad rows with trailing commas and drop spaces). Watch for Excel reformatting the 10-digit SNs (e.g. scientific notation) or the timestamp line; that risk exists today and is not changed by this plan.
- T-13d: A first-weight bag closed with only event lines (manual stop) loads in post-weigh without a crash.

## 7. Finish

- Update `RELEASE_NOTES.md` (2.6.4.3 entry): one bullet per behavior change, with SR IDs.
- Commit on `feature/wronggas-duplicate-lockout` with a message listing the SR IDs. Do not push. Do not publish.
- Merge into `Version_2_6_4_0` only after Greg's bench test passes, and only when Greg says so.
- Give Greg a summary of what changed per file, so he can update the "Code change summary" section of the requirements doc.
