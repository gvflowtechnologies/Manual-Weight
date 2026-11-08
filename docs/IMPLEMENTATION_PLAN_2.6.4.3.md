# Implementation Plan: SWAMY 2.6.4.3 (wrong-gas, duplicate SN, password lockout)

Status: **PLAN ONLY - not approved for coding.** Review with Greg and get explicit approval before editing any code.

- Branch: `Version_2_6_4_0`
- Source of truth: Claude Doc "SWAMY Sorter Disposition Requirements & Pass/Fail Criteria" (https://claude.ai/artifact/6YKR3ZdereADxeyRCirUjV). The requirements and tests in scope are copied below so this file stands alone.
- Background: protocol PVP-102-014-042 Rev C (IOPQ) and the review doc "SWAMY IOPQ Protocol Review" (https://claude.ai/artifact/BvUyBWFZ8ZarSv8tDdFdQp), findings F1-F14.
- Decisions on open questions came from Andrew Hill (protocol originator), 8 Nov 2026.

## 0. Starting state (check before anything else)

- Commit `2fa3ea4` ("baseline on updates") holds the Form1.vb line 279 units fix (TareLimit mg -> g) and the new `RELEASE_NOTES.md`. Ask Greg whether that build has been bench-checked; it is the baseline for this change set.
- Commit `292ac3e` (20 Oct 2026) holds the sort-timeout and wrong-gas fixes (SR-01 to SR-09). Last publish was 2.6.4.2. `ApplicationRevision` is already 3, so the next publish is 2.6.4.3. Do not change version settings and do not publish.

## 1. Requirements in scope

| ID | Requirement (summary; the Claude Doc has the full wording) |
| --- | --- |
| SR-06 | A SN already in the current bag still raises the duplicate SN error; handled per SR-11 and SR-12. |
| SR-07 | Wrong-gas SN (first digit not 1 = SF6 / 2 = C3F8 for the lot): show "Incorrect Serial Number. Halt Production to Investigate", red HALT, open the bad chute, and **wait up to 15 s for the drop**. |
| SR-08 | On a detected drop: write a data file line (SN, "Wrong Gas") and **add 1 to the bad count**; then supervisor password (SR-14), close chute, clear SN field, return to Scan. Not weighed. |
| SR-10 | Wrong gas, no drop within 15 s: close chute, show "Wrong gas cylinder not in bad bin", password (SR-14). Write line (SN, "Wrong Gas - Not Sorted"); **do not** add to the bad count. |
| SR-11 | Duplicate SN (first-weight and post-weigh): show the duplicate error, open the bad chute, wait up to 15 s. On drop: write a line for the duplicate scan (SN, "Duplicate SN") in scan order, bad count +1, password (SR-14), close chute, return to Scan. Not weighed. No drop: as SR-10 with "Duplicate SN - Not Sorted". |
| SR-12 | The **first instance** of a duplicated SN is also marked "Duplicate SN" in the data file, in both modes. In first-weight mode the first instance is rejected at post-weigh. Counts are not changed and SWAMY gives no instruction to move the part (file mark only; NCR handles it). |
| SR-13 | Lines written under SR-08, SR-10, SR-11 do not count toward the parts expected at post-weigh and are not read as first weights, so the post-weigh bag still closes on its own after the last real part. |
| SR-14 | Every supervisor password prompt (sort timeout, wrong gas, duplicate) behaves as SR-03: 6 attempts, attempts remaining shown after each wrong entry, on the 6th "Incorrect password entered 6 times. The bag will be closed." and the bag closes. Cancel or blank counts as a wrong entry. |

Unchanged and must keep working: SR-01 to SR-05 (sort timeout), SR-09 (empty SN).

## 2. Where the code changes (current behavior -> required)

| Area | File / member | Today | Change |
| --- | --- | --- | --- |
| Password prompts | `Form1.vb`: timeout loop in `Tmr_ScreenUpdate_Tick` (prompting, ~line 300), duplicate loop (~line 203), wrong-gas loop in `SN_Validating` (~line 1090) | Only the timeout has the 6-attempt limit; the other two loop forever, and Cancel ("") loops | One shared helper, e.g. `Function RequireSupervisorPassword(title As String) As Boolean` (False = locked out). Callers close the bag and exit on False. Reuse the existing `MaxSupervisorAttempts = 6` and messages (SR-03/SR-14). |
| Wrong gas | `Form1.vb` `SN_Validating` | Opens the bad chute, password, closes the chute. No drop wait, no log, no count | Sort(2) -> `cylindersorter.Dropped` (blocks up to 15 s) -> drop: log "Wrong Gas" and bad count +1; no drop: Sort(255), message, log "Wrong Gas - Not Sorted". Then password, Sort(255), clear SN, Scan. |
| Duplicate | `Form1.vb` scanning state, ~line 203; `PalletData.SN_Already_Exists` | Error + password; chute stays closed; first instance's weight overwritten with -20 | Same pattern as wrong gas (SR-11). Replace the -20 overwrite with an explicit "Duplicate SN" status on the first instance (SR-12). |
| Bad count | `Form1.vb` `Updatecounts` | Driven by `ccylinder.Disposition` | Add a path that adds 1 to `MDataset.Numbad` and `My.Settings.TotalBad` for logged events without a weighed cylinder. |
| First-weight file | `Write_Totals_FirstWT`, `PalletData.Readfirstweight`, `Initialweight`, `PalletComplete` | Lines `SN, FirstWt` written at bag close from `CylinderList`; reader treats every line before END_OF_DATA as a part | Add an optional 3rd column (status / event text). Event lines (wrong gas, duplicate scan) are written in scan order but skipped by the reader for first weights and for `number_of_Canisters` (SR-13). First instance with status "Duplicate SN" is read as a part and rejected at post-weigh. |
| Post-weigh file | `Write_second_weight`, `PalletData.GetCurrentCount` | One line per part, written at once; resume count = line count - 5 | Event lines appended at once in the existing column layout (`SN, , , , False, <event text>`). Mark the first instance (see design point D2). Resume count must count part lines only. |
| Disposition | `Cylinder.DetermineDisposition` | -20 first weight -> "Incorrect Serial Number" | Status "Duplicate SN" from the first-weight file -> reject with reason "Duplicate SN". Keep the -20 path for an SN missing from the first-weight file. |

## 3. Design points to settle in the plan review (propose, don't decide alone)

- **D1. Data model.** Recommended: keep one ordered list per bag (scan order) with a record type (Part, WrongGas, WrongGasNotSorted, DuplicateScan, DuplicateScanNotSorted) plus a status on Part records. The duplicate check (`SN_Already_Exists`), `PalletComplete`, counts and the expected-part count consider Part records only. The alternative is a separate event list merged by time at write.
- **D2. Marking the first instance in post-weigh.** Its line is already in the Completed file. Option A: rewrite that line's Fail Code to "Duplicate SN", keeping the Disposition as recorded (safe read-modify-write of the file). Option B: append a marker line referencing it. Option A keeps one line per part; recommended, but confirm with Greg.
- **D3. Backward compatibility.** First-weight files written by 2.6.4.2 (two columns, -20 for duplicates) may be sitting in "In Process" when 2.6.4.3 is installed. The reader must accept both formats.
- **D4. Lockout inside `SN_Validating`.** Closing the bag from inside the Validating event (CausesValidation, focus, `e.Cancel`) needs care; keep the scanning state consistent afterwards.
- **D5. UI freeze.** `CSorter.Dropped` busy-waits up to 15 s on the UI thread (existing behavior for normal sorts). Acceptable for consistency; note it, don't redesign it.

## 4. Out of scope for this change set (do not fix without a separate decision)

Review-doc findings still open: F2 (post-weigh bag auto-close vs. Att. 14), F3 (timeout rescan counted twice in post-weigh via `Initialweight` incrementing `canisternumber`), F5 (Archived copy crash on rerun), F6 (ALL02 parsing has no error handling), F10-F14. SR-13 touches the same counting code as F2/F3, so call out any interaction you see, but don't change F3 behavior unless Greg approves.

## 5. Verification

Build: `msbuild "Manual Scale Operation.sln"` (or Visual Studio). Requires the MCC DAQ (MccDaq) library on the machine. There are no automated tests; the scale and sorter are hardware, so tests are bench tests run by Greg.

Bench tests from the requirements doc (run T-01 to T-03, T-06, T-08, T-10 in both first-weight and post-weigh modes):

| Test | Pass criteria (summary) |
| --- | --- |
| T-01/T-02 Sort timeout good/bad | Unchanged (regression). |
| T-03 Duplicate SN | Duplicate error; bad chute opens; password only after the drop; bad count +1, good unchanged; both instances marked "Duplicate SN" in scan order. |
| T-04 Normal sort | Unchanged (regression). |
| T-05 Timeout lockout | Unchanged (regression). |
| T-06 Wrong gas, dropped | HALT message; bad chute opens; password only after the drop; bad count +1; one "Wrong Gas" line; not weighed. |
| T-07 Empty SN | Unchanged (regression). |
| T-08 Wrong gas, not dropped | Chute closes after 15 s; "not in bad bin" message; password; bad count unchanged; one "Wrong Gas - Not Sorted" line. |
| T-09 Duplicate first weight -> post-weigh | First-weight file marks both; first instance rejected at post-weigh with reason. |
| T-10 Duplicate, not dropped | As T-08 with "Duplicate SN - Not Sorted"; first instance still marked. |
| T-11 Post-weigh close with logged lines | Bag closes on its own after the last real part; nothing left unprocessed. |
| T-12 Lockout at wrong-gas and duplicate prompts | Same as T-05 at both; Cancel counts as a wrong entry. |

## 6. Finish

- Update `RELEASE_NOTES.md` (2.6.4.3 entry): one bullet per behavior change, with SR IDs.
- Commit on `Version_2_6_4_0` with a message listing the SR IDs. Do not push. Do not publish.
- Give Greg a summary of what changed per file, so he can update the "Code change summary" section of the requirements doc.
