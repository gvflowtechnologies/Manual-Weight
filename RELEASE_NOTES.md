# SWAMY Release Notes

## 2.6.4.3 (unreleased)

Branch: Version_2_6_4_0. Fixes found during SWAMY #2 IOPQ (PVP-102-014-042 Rev C).

### Fixes

- **Sort timeout no longer records an unsorted cylinder (SR-03 to SR-05).** After a sort timeout and supervisor password, the cylinder is discarded: it is not added to the bag, not written to the data file and not counted. The operator is told to rescan, and the rescan no longer raises a duplicate SN error. The password allows 6 attempts; on the 6th wrong entry the bag is closed with the message "Incorrect password entered 6 times. The bag will be closed."
- **Wrong gas serial number now opens the bad part chute (SR-07, SR-08).** A serial number whose first digit does not match the lot gas type (1 = SF6, 2 = C3F8) shows "Incorrect Serial Number. Halt Production to Investigate" and a red HALT, opens the bad part chute, and requires the supervisor password. The chute then closes and the cylinder is not weighed, recorded or counted.
- **Empty serial number no longer causes a software error (SR-09).** Shows "No Serial Number Entered".
- **Weight capture threshold units corrected.** The scale reading had to exceed Min Weight - 2 x Re-tare Limit before a weight was recorded, but the Re-tare Limit (entered in mg) was used as grams. The threshold was 0.6 g below Min Weight at the default 0.3 mg Re-tare Limit; it is now 0.0006 g below, matching the taring check.

### Behavior changes to note for validation

- A part lighter than Min Weight - 2 x Re-tare Limit is not recorded; SWAMY stays at "Place" with no message. After the units fix this is effectively anything below Min Weight, so such parts are no longer rejected as "Too Low".
- PVP-102-014-042 Att. 16 simulates a bad part with a 2 g weight and Min Weight set to 3.0 g. The 2 g weight is not recorded under either the old or the new threshold, so that step needs a protocol redline (for example, lower Max Weight below the cylinder weight so a real cylinder is rejected as "Too High").
