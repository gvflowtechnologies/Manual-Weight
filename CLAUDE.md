# CLAUDE.md - SWAMY (Manual-Weight)

SWAMY (Semi-automated Weight Assessment of Microcylinders) is a VB.NET Windows Forms app (.NET Framework) that weighs SF6 and C3F8 valved cylinders before and after heat conditioning, compares against ALL02 fill data, and drives a two-chute sorter. It is under formal process validation (protocol PVP-102-014-042 Rev C), so changes must be deliberate, minimal and traceable.

## Working rules (from Greg - always follow)

1. **Plan before code.** Do not edit code until Greg has reviewed and approved a written plan for that change. If you find something unplanned that needs changing, stop and propose it.
2. **Requirements are the source of truth.** Trace every behavior change to a requirement ID (SR-xx) and a test (T-xx). The current plan is `docs/IMPLEMENTATION_PLAN_2.6.4.3.md`.
3. **Never push and never publish.** Commit locally on the current branch only when Greg says so. Do not change ClickOnce/publish settings, the version, or the signing certificates (`*.pfx`).
4. **Keep changes minimal.** No refactoring, renaming or reformatting beyond what the plan calls for. Do not change `My.Settings` defaults.
5. **Release notes.** Every behavior change gets a line in `RELEASE_NOTES.md` under the unreleased version.
6. **Build before you say it's done.** Build the solution and fix all errors. Say clearly that hardware behavior (scale, sorter) still needs Greg's bench test.

## Repo facts

- Solution: `Manual Scale Operation.sln`; project in `Manual Scale UI/`.
- Key files: `Form1.vb` (UI and the weighing state machine in `Tmr_ScreenUpdate_Tick`), `PalletData.vb` (bag data, first-weight and ALL02 file reading), `Cylinder.vb` (disposition rules), `CSorter.vb` (MCC USB-1208 DAQ: chutes and drop sensors), `ScaleManagement.vb` (Mettler Toledo scale over serial).
- Source files are UTF-8 with BOM and CRLF line endings; keep them that way. `.gitattributes` has `* text=auto`.
- Data folders under `My.Settings.File_Directory`: `In Process` (first-weight files), `Completed` (post-weigh files), `Archived` (first-weight files moved here when post-weigh starts).
- Units: weights and limits are in grams, except `TareLimit` and `TareError` (mg) and ALL02 tare values (mg).
- SF6 serial numbers start with 1, C3F8 with 2; serial numbers are 10 characters.
- SWAMY #1 and #2 are separate machines with local storage only; nothing is shared between them.
- Builds need the MCC DAQ (`MccDaq`) library installed. There are no automated tests.
