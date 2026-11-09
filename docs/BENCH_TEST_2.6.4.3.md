# SWAMY 2.6.4.3 Bench Test Instructions (T-01 to T-21)

Informal bench check of the 2.6.4.3 changes before formal IOPQ execution. The pass criteria come from "SWAMY Sorter Disposition Requirements & Pass/Fail Criteria" (SR-01 to SR-14) and "SWAMY 2.6.4.3 Change Plan (SR-15 to SR-20)", so SR-01 to SR-20 in all. A test passes only if every expected result is seen; anything else is a fail, so write down what actually happened.

| Record | Value |
| --- | --- |
| Tester / date | |
| SWAMY unit (#1 / #2) and its Bag Capacity | |
| Branch / commit | feature/wronggas-duplicate-lockout / 3745b8a (code, SR-01 to SR-20). Later commits are docs only; the code matches 3745b8a. |
| Version shown on screen | |

## 1. Setup

- [ ] Build from the commit above, installed on the bench unit, with the sorter and scale connected.
- [ ] Settings page: **Sorter Attached** is checked. Record Min Weight ____ g, Max Weight ____ g, Re-tare Limit ____ mg, Bag Capacity ____.
- [ ] Bag Capacity is higher than the number of good parts in any first-weight bag below, so first-weight bags are closed with STOP.
- [ ] Supervisor password is known. For the lockout tests (T-05, T-12) you will enter wrong passwords on purpose.
- [ ] Parts: 6 SF6 cylinders (SN starts with 1), labelled S1 to S6 below, and 2 C3F8 cylinders (SN starts with 2), C1 and C2, all with readable 10-character labels. Write the SNs here: S1 ____ S2 ____ S3 ____ S4 ____ S5 ____ S6 ____ C1 ____ C2 ____
- [ ] For T-14, T-15 and T-18: 10 more distinct SF6 cylinders, N1 to N10, plus one more, N11, for T-18. All 11 must be in the ALL02 file. N1 to N10 can be reused in different bags. Write the SNs here: N1 ____ N2 ____ N3 ____ N4 ____ N5 ____ N6 ____ N7 ____ N8 ____ N9 ____ N10 ____ N11 ____
- [ ] An ALL02 file that contains all of the SNs above (needed to start post-weigh).
- [ ] Unfilled parts will fail fill mass. If you need a "good" part, open the SF6 and C3F8 net-weight limits for the bench session and record the values. Put them back afterwards.
- [ ] "Bad" part: lower **Max Weight** below the cylinder weight (about 4.85 g), e.g. 4.0 g, so a real cylinder is rejected "Too High". Do not use the 2 g weight method (F4).
- [ ] Before starting, back up the `In Process`, `Completed` and `Archived` folders.

**Drop timing:** "drop" = place the cylinder in the open chute within 15 s. "Don't drop" = hold the cylinder and wait more than 15 s.

**Use a new Bag # / Batch for each bag below**, except where a test says to reuse one. Reusing a batch and bag is now refused before any file is changed (SR-16 to SR-18); T-16, T-17 and T-19 check this. A physical part can be used again in a different bag.

**Refusal checks (T-16, T-17, T-19, T-20, T-21):** before and after each refusal, record the file listing of `In Process`, `Completed` and `Archived` with each file's size and modified time (e.g. File Explorer "Details" view, or `dir` in a command window). "No file changes" means the two listings are identical.

**Duplicate SNs in post-weigh:** a "Duplicate SN - First Instance" marker is written only once per SN, and not at all for an SN that was already a duplicate in first weight (its own line already says "Duplicate SN"). So in post-weigh, T-09, T-03 and T-10 must each use a different SN, as listed below.

**Notes:**
- Record Bag Capacity on SWAMY #1 and #2 before running PVP-102-014-042 Att. 17, 18 and 20. It must be at least 300.
- While running T-11, watch for a second "Finalizing Bag" or "Bag Complete" during the 15 s "Finalizing Bag" wait (nested close). Record it if seen; it is a bench observation, not a fail.
- T-14, T-15 and T-18 need 10 or more distinct SNs in one bag, all in the ALL02 file (N1 to N10).

## 2. Bags and order

| Bag | Gas | First weight | Post-weigh |
| --- | --- | --- | --- |
| A | SF6 | T-04 (S1 good, S2 bad), T-01 (S3), T-02 (S4), T-03 (S5, then S5 again), T-10 (S5 again), T-06 (C1), T-08 (C1), then STOP | In this order: T-09 (S5), T-04 (S1 good, S2 bad), T-03 (S1 again), T-10 (S2 again), T-06 (C1), T-08 (C1), then S3 and S4 as the last real parts for T-11. **No timeouts in Bag A post-weigh.** |
| B | SF6 | S1, S2, S3, S4 sorted normally, then STOP | T-01 (S1), T-02 (S2), then S3 and S4. The bag closes on its own after S4, not before (SR-15). |
| C | C3F8 | C1 sorted normally, T-06 (S6), then STOP | T-06 (S6), then C1 as the last real part (bag closes on its own). |
| D | SF6 | T-05 | - |
| E, F, G | SF6 | T-12 (one lockout per bag) | - |
| H | SF6 | S1 to S4 sorted normally, then STOP | T-17: S1 and S2, then STOP; then the two restart attempts. |
| I | SF6 | N1 to N10 (N1 to N5 good, N6 to N10 bad), then STOP | T-14 run 1: every part times out once, then is rescanned. |
| J | SF6 | N1 to N10 (N1 to N5 good, N6 to N10 bad), then STOP | T-14 run 2: only N1 and N6 time out once. |
| K | SF6 | N1 to N10, then STOP | T-15 |
| L | SF6 | N1 to N10, then STOP | T-18 (N11 is not in this bag) |
| M | SF6 | S1, S2, then STOP | Run to the automatic close, then T-16. |
| - | - | T-07, T-13a, T-13c, T-13d, T-19, T-20, T-21 as described | |

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
- Bag B post-weigh: each timed-out part counts once toward the bag total, on its rescan (SR-15). After T-01 and T-02, weigh S3 and S4: the bag stays open until S4 is recorded, then closes on its own. P / F

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
- Disposition total: in Bag A's Completed file, the number of `False` values in the Disposition column equals the `Bad, n` total at the bottom. (A bag can no longer be resumed (SR-17), so this applies to every post-weigh bag.)
- Watch the 15 s "Finalizing Bag" wait for a nested close (see the notes in section 1).
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
Pass for T-13 as a whole: an old 2.6.4.2 file loads, its -20 part is rejected and the bag closes on its own after the last part; a file edited off the SWAMY PC loads; an empty file gives no error; and the event line is written even when the bag closes on a lockout (checked in T-12).
- **T-13a:** Put a 2.6.4.2 first-weight file containing a `-20` weight in `In Process` (from an old run, or a copy edited by hand). A hand-edited file must keep the `Batch_Bag_M_D_YYYY_.csv` name pattern, and its SNs must be in the ALL02 file. Post-weigh it, processing every part in the file, including the -20 part. Expected: it loads; the -20 part is rejected "Incorrect Serial Number"; the bag closes on its own after the last part, not earlier, and not never. P / F
- **T-13b:** replaced by T-17 (post-weigh can no longer be resumed).
- **T-13c:** Pre-weigh a fresh bag on SWAMY. Copy its first-weight file off the SWAMY PC, open it in Excel on another PC, save it as CSV, close Excel, and copy it back to `In Process` (replacing the original). Before post-weighing, check the SNs in the file are unchanged (no lost leading characters, no scientific notation). Then post-weigh it. Expected: it loads and the parts look up normally. If the SNs change or the header lines (batch or timestamp) break the load, record it as a "T-13c finding". P / F
- **T-13d:** First-weigh a bag with only a wrong-gas scan, then STOP. Post-weigh that bag. Expected: no crash; the bag goes straight to "Finalizing Bag" because no parts are expected. P / F

### T-14 Post-weigh count with sort timeouts (SR-15)
1. Bag I (N1 to N5 good, N6 to N10 bad in first weight). In post-weigh, for each part: weigh it, don't drop it for more than 15 s, enter the password, then rescan and drop it in the correct chute (the Att. 16 pattern).
2. Bag J: as step 1, but only the first part of each group (N1 and N6) times out; the rest are sorted normally.
- Expected (both bags): each part is recorded once, on its rescan; the bag closes on its own after the 10th recorded part and not earlier; no part is left unprocessed; the good and bad counts match the parts in each bin.
- Bag I: P / F  Bag J: P / F  Notes:

### T-15 Post-weigh duplicates do not close the bag (SR-15, SR-11, SR-13)
1. Bag K. In post-weigh, weigh N1 to N5 normally.
2. Rescan N1 to N5 as duplicates, dropping each in the bad chute and entering the password (the Att. 13 pattern).
3. Press STOP.
- Expected: the bag stays open after step 2 and STOP works; the Completed file has 5 recorded parts plus the duplicate and first-instance marker lines for each of N1 to N5; the bad count went up by 5 in step 2.
- P / F  Notes:

### T-16 Archived first-weight file already exists (SR-16)
1. Bag M: post-weigh it to the automatic close.
2. Copy Bag M's first-weight file from `Archived` back to `In Process` (same name; the Archived copy stays). Move Bag M's file out of `Completed` to a backup folder.
3. Record the folder listings. Start post-weigh with Bag M's batch and bag.
- Expected: "A first-weight file for this batch and bag has already been archived. Use a new batch name."; no exception; the process and gas buttons are enabled again; the archived file and the In-Process file are unchanged (compare the listings).
4. Then start a valid bag with a new batch name and run it to the automatic close.
- P / F  Notes:

### T-17 Post-weigh cannot be resumed (SR-17)
1. Bag H: start post-weigh, weigh S1 and S2, then press STOP.
2. Move Bag H's first-weight file from `Archived` back to `In Process`. Record the folder listings. Start post-weigh with Bag H's batch and bag.
3. Move the file back from `In Process` to `Archived`. Record the folder listings. Start post-weigh with Bag H's batch and bag again.
- Expected (steps 2 and 3): "Post-weigh has already been started for this bag and cannot be resumed. Use a new batch name."; nothing resumes and no "Existing Progress Found" prompt appears; the In-Process, Archived and Completed files are unchanged (compare listings, sizes and times).
4. Then start a valid bag with a new batch name and run it to the automatic close.
- Step 2: P / F  Step 3: P / F  Notes:

### T-18 Unknown SN in post-weigh (SR-15)
1. Bag L (N1 to N10). In post-weigh, first scan N11 (in the ALL02 file, not in Bag L) and drop it in the bad chute.
2. Then process N1 to N10.
- Expected: N11 goes to the bad chute with reason "Incorrect Serial Number" and is recorded as bad; the bag count does not advance for it; the bag closes on its own after the 10th real part, not earlier.
- P / F  Notes:

### T-19 Pre-weigh batch and bag already used (SR-18)
Use a batch and bag not used in any other test, e.g. batch T19, bag 1. Record the folder listings before and after each start.
1. (a) Put a file named `T19_1_<earlier date>_.csv` (e.g. `T19_1_11_1_2026_.csv`) in `In Process` (copy any first-weight file and rename it). Start pre-weigh for T19 / 1. Remove the file afterwards.
2. (b) Put a file named `T19_1_<today>_.csv` in `Completed` (and repeat with `Archived`). Start pre-weigh for T19 / 1. Remove the files afterwards.
3. (c) Put a file named `T19_1_<earlier date>_.csv` in `Completed` or `Archived` only. Start pre-weigh for T19 / 1.
- Expected: in (a) and (b), "Batch and bag already used. Use a new batch name." and no file is created or changed; in (c) pre-weigh starts normally (STOP it afterwards).
4. After each refusal, start a valid bag with a new batch name and run it to the automatic close.
- (a): P / F  (b): P / F  (c): P / F  Notes:

### T-20 Exact batch and bag matching (SR-19)
Create these first-weight files in `In Process` (copy a real first-weight file and rename it; the SNs must be in the ALL02 file). Use today's date unless stated.
- `A1_1_<date>_.csv` and `A10_1_<date>_.csv`
- `A_1_<date>_.csv` and `A_1_1_<date>_.csv` (batch A and batch A_1, both bag 1)
- A bag number that appears in today's date (on 9 Nov use bag 1, 2 or 9; e.g. batch D, bag 9) next to a file for a different bag of the same batch (e.g. `D_11_<date>_.csv`)
- A mixed-case pair: batch `a1` and batch `A1` (use a different bag, e.g. bag 2)
- Two files for the same batch and bag with different dates, named by hand (e.g. `DUP_1_11_1_2026_.csv` and `DUP_1_<today>_.csv`)
1. Start post-weigh for each exact batch and bag (A1/1, A10/1, A/1, A_1/1, D/9, D/11). Check the batch and bag shown, then STOP the bag (its first-weight file moves to `Archived`).
2. Start post-weigh for a1/2.
3. Start post-weigh for DUP/1.
4. Start pre-weigh for A1 / bag 3 while `A10_3_<date>_.csv` is in `In Process`.
- Expected: each start loads only the exact batch and bag; A1 never matches A10; A never matches A_1; a bag never matches because of its date; a1 and A1 are the same batch (with both present for the same bag, the SR-19 message shows); DUP/1 shows "More than one first-weight file matches this batch and bag. Contact Supervisor." and no file changes; pre-weigh for A1 is not refused because A10 exists.
- P / F  Notes:

### T-21 Unrecognized file in In Process (SR-20)
1. Put a valid first-weight file and a copy of it with " (2)" added to its name (e.g. `U_1_<date>_ (2).csv`) in `In Process`. Record the folder listings. Start post-weigh for U / 1.
2. Remove both. Put valid files for batch A and batch A_1, both bag 1, in `In Process`. Start post-weigh for A / 1.
- Expected: step 1 shows "Unrecognized file for this batch and bag in In Process. Contact Supervisor." and no file changes; step 2 starts normally with no refusal.
- Step 1: P / F  Step 2: P / F  Notes:

## 4. Afterwards

- [ ] Put back any settings changed for the bench session (Max Weight, net-weight limits) and record them.
- [ ] Keep copies of the data files and folder listings from each bag with this sheet.
- [ ] Note anything unexpected, even if it's not a fail, e.g. the screen freezing during the 15 s drop wait, or a nested close during "Finalizing Bag".
- [ ] Bring the results back to update the requirements doc and the review doc (including the T-13c finding, if T-13c fails).
