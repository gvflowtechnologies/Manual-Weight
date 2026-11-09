SWAMY 2.6.4.3 - implementation brief for Claude Code

ABOUT THIS BRIEF
Greg is the owner. The plan behind this brief is "SWAMY 2.6.4.3 Change Plan (SR-15 to SR-20)", approved by Greg on 9 Nov 2026 (all checklist items ticked). Requirement texts below are authoritative and replace anything older, including the older SR-15 wording you quoted in your A2f/A7 answers. Repo: Manual-Weight. Branch: feature/wronggas-duplicate-lockout. Start from HEAD 9da4fb8 (code identical to 8f800e9). Release: 2.6.4.3. All line numbers come from your 9 Nov report, so verify them before using them.

GATE (read this first)
- Phase 0 is read-only. Do not edit, build, commit or run anything that changes files until Greg types APPROVED in this session.
- Phase 0 output: answer the questions in section 1 and give a short edit outline (file, function, what changes, in words). Then stop and wait.
- If anything in this brief conflicts with the code, stop and tell Greg. Do not resolve it yourself.

RULES (all phases)
- Change only what is listed. No refactors, renames, formatting-only edits or cleanups.
- Messages must match the quoted text exactly.
- One code commit covering SR-15 to SR-20, and a separate docs commit. Do not push, merge, publish or change the version.
- Every refusal must happen before any file is created, moved, copied, deleted or written, and must change no file.
- You cannot bench test. Say what you verified by reading and by build only.

1. PHASE 0 QUESTIONS (read-only)
1. Confirm each line reference in section 3 against HEAD, and list any that moved.
2. List every caller of Firstweight (PalletData.vb:122 area). SR-19 changes its matching for all callers.
3. How does pre-weigh start compute the date used in the file name (PalletData.vb:463-471)? SR-18 must use the same value.
4. Is any other code building or comparing first-weight file names in In Process, Completed or Archived (including Wasthisfilealreadystarted, GetCurrentCount, Writefileheader2)? List each so they can use the shared helper or be left alone.
5. Can Completed or Archived hold non-csv files or subfolders? How should the helper treat them?
6. Which functions create the radio-button state at 534 and 549? What must a refusal call to re-enable them?

2. REQUIREMENTS (authoritative text)
SR-15 (F3). In post-weigh mode, the count that closes the bag shall advance by one for each cylinder that matches a part in the first-weight file and is recorded after its drop is detected, and only then. A scan that ends in a sort-timeout discard (SR-04), a logged line (SR-08, SR-10, SR-11, SR-12) or a serial number not in the first-weight file shall not advance it. The bag shall close on its own when the count equals the number of parts in the first-weight file, with no part left unprocessed.
SR-16 (F5). At post-weigh start, if an archived first-weight file with the same name already exists, the software shall not overwrite or delete it and shall not raise a software error. It shall show "A first-weight file for this batch and bag has already been archived. Use a new batch name." and return to batch selection with every file unchanged.
SR-17 (F15, F16). Post-weigh shall not resume a bag. If a Completed file already exists for the selected batch and bag, the software shall show "Post-weigh has already been started for this bag and cannot be resumed. Use a new batch name." and return to batch selection with every file unchanged. This check shall run first, before SR-16 and before any file is moved, copied or deleted.
SR-18. At pre-weigh start, the software shall not start the bag if In Process holds a first-weight file for the same batch and bag on any date, or if Completed or Archived holds one for the same batch, bag and date. It shall show "Batch and bag already used. Use a new batch name." and return to batch selection with every file unchanged. A batch and bag can be used only once per day, and not again while its first-weight file is waiting in In Process.
SR-19. A batch and bag shall select a first-weight file only when the file name is the batch, the bag and a date (month, day, year) joined by underscores and ending in "_.csv". The name shall be read from the right: the last three numeric fields are the date, the field before them is the bag, and the rest is the batch. The batch may contain underscores; the bag shall not. Names shall be compared without regard to letter case and ignoring leading and trailing spaces. A batch or bag that is only part of another name (batch A1 against A10, batch A against A_1, a bag against a date containing it) shall not match. If more than one file matches, the software shall refuse with "More than one first-weight file matches this batch and bag. Contact Supervisor." and not treat it as not found. The same rule applies at pre-weigh start (SR-18) and post-weigh start (SR-16, SR-17).
SR-20. At post-weigh start, after the first-weight file is selected, if In Process holds another file whose name starts with the batch and bag followed by an underscore and does not parse as a first-weight file for a different batch and bag (for example a renamed copy), the software shall show "Unrecognized file for this batch and bag in In Process. Contact Supervisor." and return to batch selection with every file unchanged. This check runs before SR-16.

3. EDITS BY REQUIREMENT
SR-15
- Remove the count increment from Initialweight (PalletData.vb:608) so the lookup has no side effect.
- At lookup, store a "matched" flag on the cylinder object: True when the serial number matches a first-weight line (including old lines with a -20 weight and pre-weigh rejects), False otherwise. Do not test for weight = -20.
- Add a post-weigh-only increment of the count beside AddCylinder and Write_second_weight (Form1.vb:337-339), after the drop is confirmed (313), and only when the cylinder's matched flag is True. The sort-timeout discard path (329-333) must never reach it.
- Unchanged: the pre-weigh close at Bag_Limit (CountGood), Updatecounts, the duplicate path (203-229), the wrong-gas path (1173-1190), the event-line exclusion when reading the first-weight file (PalletData.vb:315), and the comparison in PalletComplete (PalletData.vb:361).
SR-17
- New check in Btn_StartPallet_Click after the batch and bag prompts (about 602) and before Firstweight (609).
- If a first-weight file is waiting in In Process for this batch and bag, look for the same exact file name in Completed. If none is waiting in In Process (the usual restart case), look in Completed for any file that parses to this batch and bag on any date. If found, refuse.
- Remove the GetCurrentCount call (615) and the method (PalletData.vb:140-186), including the "Existing Progress Found" dialog. Keep the Writefileheader2 guard (792) as a backstop. Greg approved this in the plan.
SR-19
- Write one shared helper in PalletData that parses a file name from the right: strip the trailing "_.csv" (case-insensitive); split on "_"; the last three fields must be all digits (month, day, year); the field before them must be all digits (bag); the remaining fields, rejoined with "_", are the batch and must not be empty. Anything else is "not a valid first-weight name".
- Examples. "Batch_1_11_9_2026_.csv" gives batch Batch, bag 1, date 11/9/2026. "A_1_1_11_9_2026_.csv" gives batch A_1, bag 1. "A_1_11_9_2026_ (2).csv" is not valid. "A1_1_..." and "A10_1_..." are different batches.
- Compare batch and bag with OrdinalIgnoreCase after Trim. Use this helper in the Firstweight lookup (PalletData.vb:122, used at Form1.vb:609) and in the SR-16, SR-17, SR-18 and SR-20 checks.
- If more than one valid file matches the batch and bag (including the same batch and bag on different dates in In Process), refuse with the SR-19 message. This is not an SR-20 case.
SR-20
- New check after the Firstweight call (609) and before SR-16: scan In Process for files other than the selected one whose name starts with Batch + "_" + Bag + "_" (case-insensitive) and that do not parse as a valid name for a different batch and bag. If any, refuse.
SR-16
- New check after the SR-20 check and before Readfirstweight (610), in Form1, so Readfirstweight stays unchanged: if Archived already holds the selected file name, refuse.
SR-18
- Replace Wasthisfilealreadystarted (PalletData.vb:271-284, called at Form1.vb:620). In Process: refuse if any valid file parses to the same batch and bag on any date. Completed and Archived: refuse only if a valid file parses to the same batch, bag and date. Use the same date value the code uses to build the new file name (answer to Phase 0 question 3). More than one match is a refusal. Run it before WritefileHeader1.
On every refusal: show the quoted message, re-enable the radio buttons (see 549), return to batch selection and change no file.
Order at post-weigh start: existing steps up to the prompts, then SR-17, then Firstweight (609), then SR-20, then SR-16, then the existing steps from 610.

4. DO NOT TOUCH
ALL02 parsing and its error handling (F6 is handled by procedure). All02Wt2nd_Pass. The sorter code. The nested close during "Finalizing Bag" (Form1.vb:687-695): that is a bench observation only. The pre-weigh Good counter display (F10 is a protocol redline).

5. DOCS COMMIT (after the code commit)
Revise docs/BENCH_TEST_2.6.4.3.md:
- Add tests T-14 to T-21 (below) and update the bag table (lines 32-40) and parts list (line 17).
- Update lines 1, 3, 8, 17, 26, 32-40, 66, 106, 129-134 and 143 for the new behavior: version and requirement ranges (SR-01 to SR-20, T-01 to T-21), the commit, the resume tests.
- Replace T-13b with the T-17 refusal test (record folder listings, sizes and times before and after).
- T-13a also checks that a 2.6.4.2 file with -20 lines still closes the bag on its own.
- Rename the "F17" placeholder at lines 135 and 143 to "T-13c finding". F17 is not a finding. Run T-13c on a freshly pre-weighed bag copied off the SWAMY PC, edited on another PC and copied back, and check the serial numbers are unchanged.
- In T-16, T-17 and T-19, after the refusal start a valid bag and run it to the automatic close.
- Add notes: record Bag Capacity on SWAMY #1 and #2 before Att. 17, 18 and 20 (it must be at least 300); watch for a nested close during "Finalizing Bag" while running T-11; T-14, T-15 and T-18 need 10 or more distinct serial numbers in one bag, all in the ALL02 file.
Revise docs/IMPLEMENTATION_PLAN_2.6.4.3.md (lines 26, 84, 97, 106 and 126), or mark it superseded by the Change Plan.

TESTS (authoritative)
T-13 (revised). Setup: post-weigh a 2.6.4.2 first-weight file containing -20; post-weigh an In-Process file edited off the SWAMY PC and copied back; open a first-weight file with no part lines; trigger a lockout at a wrong-gas and a duplicate prompt. Pass: old file loads, the -20 part is rejected and the bag closes on its own after the last part; edited file loads; empty file gives no error; the event line is written even when the bag closes on lockout.
T-14 (SR-15). First-weigh 10 parts (5 good, 5 bad). In post-weigh, time out every part once, enter the password and rescan each (the Att. 16 pattern). Repeat with only the first part of each group timing out. Pass: each part is recorded once, on its rescan; the bag closes on its own after the 10th recorded part and not earlier; no part is left unprocessed; counts match the bins.
T-15 (SR-15, SR-11, SR-13). First-weigh 10 parts. Post-weigh 5, then rescan the same 5 as duplicates, dropping each in the bad chute (the Att. 13 pattern). Pass: the bag stays open and STOP works; 5 recorded parts plus 5 duplicate lines; bad count +5.
T-16 (SR-16). Run a post-weigh to the end. Recreate the In-Process file with the same batch, bag and date, and remove the Completed file. Start post-weigh. Pass: the SR-16 message shows with no exception; the archived file is unchanged and the In-Process file is untouched; then a valid bag runs to the automatic close.
T-17 (SR-17). After a post-weigh STOP, start post-weigh again for the same batch and bag, once with the first-weight file moved back and once without. Pass: the SR-17 message shows and nothing resumes; In-Process, Archived and Completed files are unchanged; then a valid bag runs to the automatic close.
T-18 (SR-15). First-weigh 10 parts. In post-weigh, scan a serial number that is in the ALL02 file but not in the first-weight file and drop it in the bad chute. Then process the 10 real parts. Pass: the unknown serial number goes to the bad chute with the "Incorrect Serial Number" reason and is recorded as bad; the count does not advance; the bag closes on its own after the 10th real part, not earlier.
T-19 (SR-18). Start pre-weigh three ways: (a) In Process holds a file for that batch and bag with an earlier date (name one by hand); (b) Completed or Archived holds one with today's date; (c) Completed or Archived holds one with an earlier date only. Pass: in (a) and (b) the SR-18 message shows and no file is created or changed; in (c) pre-weigh starts normally; after each refusal a valid bag runs to the automatic close.
T-20 (SR-19). Create first-weight files for batch A1 and batch A10, both bag 1; batch A and batch A_1, both bag 1; a bag number that appears in the test-day date (on 9 Nov use bag 1, 2 or 9) beside a file for a different bag; and a mixed-case pair, a1 and A1. Put two files for the same batch and bag with different dates in In Process by hand. Start post-weigh for each exact batch and bag. Also start pre-weigh for A1 while A10 exists. Pass: each start loads or accepts only the exact batch and bag; A1 never matches A10, A never matches A_1, a bag never matches because of its date, and a1 and A1 are the same batch; pre-weigh for A1 is not refused because A10 exists; the two files for the same batch and bag are refused with the SR-19 message.
T-21 (SR-20). Place the exact first-weight file and a copy with " (2)" added to its name in In Process, and start post-weigh. Then repeat with valid files for batch A and batch A_1, both bag 1. Pass: the first case shows the SR-20 message and no file changes; the second case starts normally with no refusal.

6. REPORT BACK
After Phase 0: the answers to section 1, the edit outline, and anything in this brief that conflicts with the code. Then wait for APPROVED.
After the build: the commit hashes; each edit as file, function and line range; how each requirement was met in words; build result and warnings; what you could not verify without hardware; and anything you found that this brief did not cover.
