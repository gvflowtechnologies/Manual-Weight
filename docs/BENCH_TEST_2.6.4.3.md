# SWAMY 2.6.4.3 Bench Test Instructions (T-01 to T-13)

Informal bench check of the 2.6.4.3 changes before formal IOPQ execution. The pass criteria come from "SWAMY Sorter Disposition Requirements & Pass/Fail Criteria" (SR-01 to SR-14). A test passes only if every expected result is seen; anything else is a fail, so write down what actually happened.

| Record | Value |
| --- | --- |
| Tester / date | |
| SWAMY unit (#1 / #2) | |
| Branch / commit | feature/wronggas-duplicate-lockout / 8f800e9. Later commits (e1acdea plan update, and the commit adding this sheet) are docs only; the code matches 8f800e9. |
| Version shown on screen | |

## 1. Setup

- [ ] Build from the commit above, installed on the bench unit, with the sorter and scale connected.
- [ ] Settings page: **Sorter Attached** is checked. Record Min Weight ____ g, Max Weight ____ g, Re-tare Limit ____ mg, Bag Capacity ____.
- [ ] Bag Capacity is higher than the number of good parts in any first-weight bag below, so first-weight bags are closed with STOP.
- [ ] Supervisor password is known. For the lockout tests (T-05, T-12) you will enter wrong passwords on purpose.
- [ ] Parts: 6 SF6 cylinders (SN starts with 1), labelled S1 to S6 below, and 2 C3F8 cylinders (SN starts with 2), C1 and C2, all with readable 10-character labels. Write the SNs here: S1 ____ S2 ____ S3 ____ S4 ____ S5 ____ S6 ____ C1 ____ C2 ____
- [ ] An ALL02 file that contains all of the SNs above (needed to start post-weigh).
- [ ] Unfilled parts will fail fill mass. If you need a "good" part, open the SF6 and C3F8 net-weight limits for the bench session and record the values. Put them back afterwards.
- [ ] "Bad" part: lower **Max Weight** below the cylinder weight (about 4.85 g), e.g. 4.0 g, so a real cylinder is rejected "Too High". Do not use the 2 g weight method (F4).
- [ ] Before starting, back up the `In Process`, `Completed` and `Archived` folders.

**Drop timing:** "drop" = place the cylinder in the open chute within 15 s. "Don't drop" = hold the cylinder and wait more than 15 s.

**Use a new Bag # / Batch for each bag below.** Reusing the same batch, bag and date crashes post-weigh start (F5, not fixed). A physical part can be used again in a different bag.

**Duplicate SNs in post-weigh:** a "Duplicate SN - First Instance" marker is written only once per SN, and not at all for an SN that was already a duplicate in first weight (its own line already says "Duplicate SN"). So in post-weigh, T-09, T-03 and T-10 must each use a different SN, as listed below.

## 2. Bags and order

| Bag | Gas | First weight | Post-weigh |
| --- | --- | --- | --- |
| A | SF6 | T-04 (S1 good, S2 bad), T-01 (S3), T-02 (S4), T-03 (S5, then S5 again), T-10 (S5 again), T-06 (C1), T-08 (C1), then STOP | In this order: T-09 (S5), T-04 (S1 good, S2 bad), T-03 (S1 again), T-10 (S2 again), T-06 (C1), T-08 (C1), then S3 and S4 as the last real parts for T-11. **No timeouts in Bag A post-weigh.** |
| B | SF6 | S1, S2, S3, S4 sorted normally, then STOP | T-01 (S1), T-02 (S2). F3 will close the bag after these two; that is expected. |
| C | C3F8 | C1 sorted normally, T-06 (S6), then STOP | T-06 (S6), then C1 as the last real part (bag closes on its own). |
| D | SF6 | T-05 | - |
| E, F, G | SF6 | T-12 (one lockout per bag) | - |
| H | SF6 | S1 to S4 sorted normally, then STOP | T-13b |
| - | - | T-07, T-13a, T-13c, T-13d as described | |

In post-weigh, wrong-gas and duplicate scans must be done **before** the last real part: the bag closes on its own after the last real part.

After each bag closes, open its data file and check the lines listed under "File".

## 3. Tests

Mark each result: P = pass, F = fail.

### T-04 Normal sort (regression)
1. Weigh a good part and drop it in the good chute. Weigh a bad part and drop it in the bad chute.
- Expected: the correct chute opens each time; each part counted once in the right count; one data file line each.
- First weight (Bag A): P / F  Post-weigh (Bag A): P / F  Notes:

### T-01 Sort timeout, good part (regression, both modes)
1. Weigh a good part. Don't drop it for more than 15 s.
2. Enter the supervisor password.
3. Rescan the same part and drop it in the good chute.
- Expected: password prompt after 15 s. After the password: "Sort Timeout - Rescan Required", back to Scan, counts unchanged, no file line. On the rescan: no duplicate error, good chute opens, good count +1, one file line.
- First weight (Bag A): P / F  Post-weigh (Bag B): P / F  Notes:

### T-02 Sort timeout, bad part (regression, both modes)
1. As T-01 with a bad part; drop it in the bad chute on the rescan.
- Expected: as T-01, except the bad chute opens on the rescan and the bad count goes up by 1.
- First weight (Bag A): P / F  Post-weigh (Bag B): P / F  Notes:
- Note (F3, not fixed): in post-weigh each timeout counts the part twice toward the bag total, so Bag B closes after T-01 and T-02 with S3 and S4 not weighed. Record it; it isn't a fail for this test.

### T-03 Duplicate SN, dropped (both modes)
1. Sort a part normally. Scan the same SN again. (First weight: S5. Post-weigh: S1, already sorted in T-04.)
2. Drop it in the bad chute within 15 s.
- Expected: duplicate message and red label; bad chute opens; **no pop-up until after the drop**; then the pop-up and the password prompt; chute closes, back to Scan; bad count +1, good count unchanged; the part is not weighed.
- File, first weight: the first instance's line ends `, Duplicate SN`; the duplicate scan has its own line `SN, , Duplicate SN`.
- File, post-weigh: two lines appended, in this order: `SN, , , , , Duplicate SN - First Instance`, then `SN, , , , False, Duplicate SN`. Earlier lines unchanged.
- First weight: P / F  Post-weigh: P / F  Notes:

### T-10 Duplicate SN, not dropped (both modes)
1. As T-03, but don't drop the part for more than 15 s. (First weight: S5 again. Post-weigh: S2, already sorted in T-04; not S1.)
- Expected: chute closes after 15 s; pop-up includes "Duplicate SN cylinder not in bad bin"; password required; bad count unchanged.
- File, first weight: one `SN, , Duplicate SN - Not Sorted` line; S5's first instance still ends `, Duplicate SN`.
- File, post-weigh: two lines appended, in this order: `SN, , , , , Duplicate SN - First Instance`, then `SN, , , , , Duplicate SN - Not Sorted` (blank Disposition).
- First weight: P / F  Post-weigh: P / F  Notes:

### T-06 Wrong gas SN, dropped (both modes, both gases)
1. In an SF6 lot (Bag A), scan a C3F8 part (C1). Drop it in the bad chute within 15 s.
2. Repeat in a C3F8 lot (Bag C) with an SF6 part (S6).
3. Optional guard check (Bag A first weight, during Scan): type a wrong-gas SN in the SN box and click Stop Bag.
- Expected (steps 1, 2): "Incorrect Serial Number. Halt Production to Investigate" and red HALT on the screen; bad chute opens; **no pop-up until after the drop**; then the pop-up and the password prompt; chute closes, SN box cleared, back to Scan; bad count +1; not weighed.
- Expected (step 3): this is the designed behavior (D4). During Scan, Stop Bag first triggers the wrong-gas handling (chute opens, then pop-up and password) and does not stop the bag; click Stop Bag again afterwards. Outside Scan (Zeroing, Place), the SN box shows "Wrong Gas Type" and keeps focus, so Stop Bag does not respond until the SN is corrected or cleared.
- File: one `Wrong Gas` line (first weight `SN, , Wrong Gas`; post-weigh `SN, , , , False, Wrong Gas`).
- SF6 lot, first weight / post-weigh: P / F, P / F. C3F8 lot: P / F, P / F. Guard check: P / F. Notes:

### T-08 Wrong gas SN, not dropped (both modes)
1. As T-06 step 1 (Bag A, C1), but don't drop the part for more than 15 s.
- Expected: chute closes after 15 s; pop-up includes "Wrong gas cylinder not in bad bin"; password required; bad count unchanged.
- File: one `Wrong Gas - Not Sorted` line (first weight `SN, , Wrong Gas - Not Sorted`; post-weigh `SN, , , , , Wrong Gas - Not Sorted`, blank Disposition).
- First weight: P / F  Post-weigh: P / F  Notes:

### T-09 Duplicate in first weight, then post-weigh
1. Bag A post-weigh, first scan: S5, the part that was a duplicate in first weight. Weigh it. Do not scan S5 again in this bag.
- Expected: the part is rejected; bad chute opens; reason "Duplicate SN" in the Completed file.
- P / F  Notes:

### T-11 Post-weigh bag close with logged lines
1. Bag A's first-weight file contains wrong-gas and duplicate lines. In Bag A post-weigh, after the tests above, weigh S3 and S4 (the last real parts).
- Expected: the bag closes on its own after the last real part; nothing left unprocessed; no error.
- Disposition total: in Bag A's Completed file, the number of `False` values in the Disposition column equals the `Bad, n` total at the bottom. (Only valid for a bag that was not resumed: the bad total resets at bag start.)
- Bag close: P / F  Disposition total: P / F  Notes:

### T-05 Password lockout, sort timeout (regression)
1. Bag D, first weight. Trigger a sort timeout. Enter a wrong password 6 times, noting each message.
- Expected: wrong entries 1 to 5 show 5, 4, 3, 2, 1 attempts remaining; the 6th shows "Incorrect password entered 6 times. The bag will be closed." and the bag closes after the 15 s "Finalizing Bag" wait. The unsorted part isn't counted or recorded.
- P / F  Notes:

### T-12 Password lockout, wrong gas and duplicate
Run all three in **first weight** mode, one new bag each. First weight writes its lines at bag close, so this also checks that a lockout still records the line. (In post-weigh the line is written before the prompt.)
1. Bag E: scan a wrong-gas part, drop it, then at the password prompt enter a wrong password 6 times.
2. Bag F: sort a part, scan it again (duplicate), drop it, then at the password prompt enter a wrong password 6 times.
3. Bag G: scan a wrong-gas part, drop it, then at the password prompt click Cancel 6 times.
- Expected: same messages as T-05 at each prompt; Cancel counts as a wrong entry; the bag closes after the 15 s "Finalizing Bag" wait; after it closes, the `Wrong Gas` / `Duplicate SN` line is in the first-weight file.
- Wrong gas: P / F  Duplicate: P / F  Cancel: P / F  Notes:

### T-07 Empty SN (regression)
1. Clear the SN box and move focus away.
- Expected: "No Serial Number Entered"; no exception or crash.
- P / F  Notes:

### T-13 File handling
- **T-13a:** Put a 2.6.4.2 first-weight file containing a `-20` weight in `In Process` (from an old run, or a copy edited by hand). A hand-edited file must keep the `Batch_Bag_M_D_YYYY_.csv` name pattern, and its SNs must be in the ALL02 file. Post-weigh it. Expected: it loads, and the -20 part is rejected "Incorrect Serial Number". P / F
- **T-13b (resume, Bag H):**
  1. Start post-weigh on Bag H. Weigh 2 real parts (S1, S2), then scan S1 again as a duplicate and drop it, then scan a wrong-gas part (C1) and drop it.
  2. **Do not press STOP.** Close SWAMY with the window's X button. (STOP adds 4 end-of-bag lines that the resume count includes: F16, not fixed.)
  3. In File Explorer, **move** (cut and paste) Bag H's first-weight file from `Archived` back to `In Process`. No copy may be left in `Archived`, or post-weigh start crashes (F5).
  4. Restart SWAMY, start post-weigh with the same Batch and Bag #, and answer Yes to resume.
  - Expected: the message shows **2** part(s) already processed (the marker, duplicate and wrong-gas lines are not counted). Weigh S3 and S4: the bag closes on its own after S4. P / F
- **T-13c:** Open a first-weight file in Excel, save it as CSV, close Excel, then post-weigh it. Expected: it loads and the parts look up normally. If the header lines (batch or timestamp) break the load, record it as F17. P / F
- **T-13d:** First-weigh a bag with only a wrong-gas scan, then STOP. Post-weigh that bag. Expected: no crash; the bag goes straight to "Finalizing Bag" because no parts are expected. P / F

## 4. Afterwards

- [ ] Put back any settings changed for the bench session (Max Weight, net-weight limits) and record them.
- [ ] Keep copies of the data files from each bag with this sheet.
- [ ] Note anything unexpected, even if it's not a fail, e.g. the screen freezing during the 15 s drop wait.
- [ ] Bring the results back to update the requirements doc and the review doc (including F16, STOP over-count on resume, and F17 if T-13c fails).
