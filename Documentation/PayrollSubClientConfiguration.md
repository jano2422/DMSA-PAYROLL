# Configurable Sub-client Payroll

## Outcome

Payroll handling is now configured at the sub-client/detachment level. The client master remains the source of truth for the daily wage, while the payroll policy controls which universal pay categories are enabled and which additional premiums or exceptional calculations apply.

The implementation aligns manual DTR entry, the payroll review grid, payroll export, payslips, and the DTR-hours report with the attached universal payroll workbook.

## Workbook findings

The universal template contains 46 labeled columns from `Employee Name` through `Signature`. The client-rule workbook defines the same 12 time/pay categories:

| Day classification | Additional premium | Effective day factor |
|---|---:|---:|
| Regular | 0.00 | 1.00 |
| Sunday | 0.30 | 1.30 |
| Legal holiday | 1.00 | 2.00 |
| Special holiday | 0.30 | 1.30 |
| Sunday + special holiday | 0.50 | 1.50 |
| Sunday + legal holiday | 1.60 | 2.60 |

Hourly ND is stored as an additional percentage of the effective day rate (normally `0.10`). OT is stored as an additional percentage of the effective day rate (`0.25` on a regular day and normally `0.30` on Sundays and holidays). The application derives the effective ND and OT factors; for example, Sunday plus legal holiday produces `2.60 × 0.10 = 0.26` ND and `2.60 × 1.30 = 3.38` OT.

The source workbook and older database rows use full factors such as `1.30`, `2.00`, and `1.69`. Import and policy loading normalize those values to additional premiums in memory. A policy is written back with `RATE_SEMANTICS=ADDITIONAL_PREMIUM_V1` only when an administrator saves or imports it; existing finalized monetary snapshots are never recalculated by this migration.

The workbook also contains client exceptions: disabled categories, overtime paid at 1.00, a fixed night-differential cutoff pool of 987.50, and a five-day incentive calculation. These are represented as policy settings instead of client-name conditions in code.

The workbook's second column also defines duty length: 71 rows use 12 hours, 13 use 8 hours, four use 10 hours, one uses 9 hours, and one uses the mixed value `8hrs/12hrs`. The 9-hour and 10-hour rows are treated as one configured shift: the first 8 hours are regular and the succeeding 1 or 2 hours are overtime.

## Configuration model

Three Access tables are created idempotently when the feature is first used:

- `PRL_SUB_CLIENT_PAY_POLICY`: one policy header per sub-client, including base hours, manual-DTR duty mode, configured single-shift hours/night flag, ND mode, incentive parameters, rate-semantics version, notes, and audit fields.
- `PRL_SUB_CLIENT_PAY_RATE`: 14 enabled/additional-premium rows per sub-client, including the two Sunday/holiday combinations. The internal `RD_SH` and `RD_LH` codes are retained for database compatibility but are displayed to users as `Sunday + special holiday` and `Sunday + legal holiday`.
- `PRL_SUB_CLIENT_PAY_POLICY_HISTORY`: immutable text snapshots for each save/import.

`OT_SUN`, `OT_LH`, and `OT_SH` are added to `PRL_DTR_TOTAL_HOURS`. Existing ND columns and `OT_REG` are retained. Finalized manual-payroll records also store the employee/client labels, wage and hours-per-day used, every earnings category amount, every deduction amount, total earnings, total deductions, net pay, calculation version, and a serialized policy snapshot. These monetary fields form the historical payroll snapshot used by later exports even if client wages or payroll rules change.

Precedence is deliberately simple: a saved sub-client policy is used when present; otherwise the standard universal policy is used. There is no hidden client-name override.

The application runs the same idempotent schema check automatically when the login screen starts. Missing payroll tables, columns, and indexes are added without a success prompt; an already-current MDB is left unchanged. If an upgrade fails, login is stopped and a sanitized diagnostic is written to `%LOCALAPPDATA%\DMSA Payroll\Logs\startup-schema.log`.

## Administrator workflow

1. Open **Payroll rules** from Manual DTR or Payroll Exports.
2. Select the main client and sub-client.
3. Enable or disable each category and enter only its additional premium (`0.30` means add 30%; it does not replace the base wage).
4. Choose whether Manual DTR follows the client schedule or uses one configured shift. For one shift, enter the total duty hours and whether it is a night shift.
5. Select ND hours, monthly ND paid by reporting days, or disabled night differential.
6. Configure the optional five-day incentive and add an explanation in Notes.
7. Save. The change is timestamped and recorded with the current user.

The **Import Excel rules** action reads `Sheet3` from the supplied client-rule workbook. Matching is based on normalized sub-client name plus location aliases when the database contains duplicate generic names. Rows containing a single 9-hour or 10-hour value automatically enable one-shift mode. The import does not update daily wage or the client-master schedule type.

## DTR and export behavior

- Manual DTR shows REG, SUN, LH, SH, four ND buckets, and four OT buckets in the same order used by the universal sheet.
- Sunday remains an explicit classification on actual Sundays and may be combined with either Special Holiday or Legal Holiday. SH and LH remain mutually exclusive. Manual DTR preserves the date-level combination and applies the configured `RD_SH` or `RD_LH` premium before falling back to the holiday, Sunday, or Regular rule.
- Worked hours are counted once. Combined Sunday/holiday earnings are reported in the existing SH or LH monetary bucket, but use the combined effective rate; hours are not duplicated into both SUN and SH/LH.
- The Manual DTR Hours Breakdown displays dedicated `SUN+SH` and `SUN+LH` rows, including combined ND and OT rows. Monetary calculation continues to use the established SH/LH, ND SH/ND LH, and OT SH/OT LH buckets, while the saved snapshot also records the combined classification as an informational subset.
- New Manual DTR snapshots also retain six combined-classification hour subsets (`SUN+SH`, `SUN+LH`, and their ND/OT variants). DTR Exports displays standalone SH/LH hours and combined hours in separate columns without changing total worked hours. The fixed 46-column `PAYROLL SHEET` recombines each standalone and combined pair into its established SH/LH input so existing formulas remain intact, while the visible `CLASSIFICATION DETAIL` sheet shows the standalone and combined hours separately for audit.
- Disabling a premium category never discards the underlying worked hours. Disabled SUN/SH/LH hours fall back to an enabled base category; disabled ND and OT variants fall back to `ND_REG` and `OT_REG` when those rules are enabled. If neither the requested category nor its fallback is enabled, the hours remain visible but intentionally produce no amount, and Manual DTR shows a warning in the preview.
- Each selected duty is one reporting day, even when several duties are selected on the same calendar date. For example, all three tri-shifts count as three reporting days; both 12-hour shifts count as two reporting days and total 24 hours.
- A configured one-shift duty always produces one reporting day. A 9-hour shift produces 8 REG and 1 OT; a 10-hour shift produces 8 REG and 2 OT. Sunday/holiday classification moves both portions into the corresponding SUN/LH/SH and OT SUN/OT LH/OT SH buckets.
- Payroll Exports shows all universal hour buckets with frozen employee columns and horizontal scrolling.
- Manual DTR accepts Other Earnings and Other Deductions alongside the named allowances and deductions. Preview, final save, individual-client export, and payslips use the same values.
- For a monthly ND amount, the calculation uses the selected-shift reporting-day count. It does not derive days from total working hours.
- The generated workbook contains `PAYROLL SHEET`, `CLASSIFICATION DETAIL`, `PAYSLIP`, `DTR_Hours`, and a very-hidden `SETTINGS` sheet. The payroll sheet uses the exact 46-column template order and policy-driven formulas; the classification sheet contains `SUN + SH`, `SUN + LH`, and their ND/OT variants without duplicating standalone SH/LH hours.
- Each payslip itemizes overtime into OT Regular, OT Sunday, OT Legal Holiday, and OT Special Holiday, showing both hours and amounts while reconciling to the unchanged total earnings value.
- Finalizing Manual DTR writes the calculated monetary snapshot, daily detail, revision metadata, and audit entry in one database transaction. Drafts and amendments retain the same data model.

## Overall payroll export

Payroll Exports now includes **Export All Active Clients**. The user selects a year, month, and cutoff, then creates one workbook without selecting an individual client.

The workbook contains:

- `SUMMARY`: active-client coverage counts and formula-driven total earnings, total deductions, and net payroll.
- `CLIENT COVERAGE`: every active main-client/detachment combination, including detachments with `NO FINAL PAYROLL` for the selected cutoff.
- `EMPLOYEE PAYROLL`: one row per latest eligible employee/detachment payroll record, with time buckets, itemized earnings, itemized deductions, totals, net pay, revision, submitter, source status, and six appended Sunday-plus-holiday columns. The ordinary SH/LH, ND, and OT hour columns show standalone hours; the appended columns show `SUN+SH` and `SUN+LH`. Monetary SH/LH columns remain inclusive and are labeled accordingly so saved payroll totals are unchanged.

New finalized records are labeled `SAVED SNAPSHOT` and use the amounts stored at finalization. Older records that predate monetary snapshots are labeled `LEGACY RECALCULATED`; these use the currently configured wage and payroll policy and must not be treated as immutable historical amounts. Only `FINAL` records and pre-workflow legacy rows are eligible; drafts and amendment drafts are excluded.

## Import reconciliation result

The supplied rule workbook was tested against a copy of the current database:

- 90 sub-clients matched and imported.
- Five 9-hour/10-hour rows were configured as one-shift policies.
- 1,080 rate rows were stored (12 per sub-client).
- 0 unmatched clients and 0 row errors remained after location-aware matching.
- The mixed `8hrs/12hrs` TUP row is reported for manual review and retains its client schedule.
- 77 workbook wages differ from client master data. These are reported for reconciliation and are intentionally not written automatically.

The wage differences require an administrator or payroll owner to decide whether the workbook or client master is correct.

## Verification evidence

- Visual Studio MSBuild Debug and Release builds: passed; the clean Release output is x86 and contains the configured `Data\Database\DMSA.mdb` path.
- Policy schema migration on a copied MDB: passed.
- Excel rule import on a copied MDB: passed.
- Fixed ND plus incentive calculation: expected and actual `11,090.078125`.
- Two-shift manual DTR calculation: 30 reporting days, 15 night days, and 360 total hours for 15 calendar dates with both shifts selected.
- One-shift manual DTR calculations: 9 hours produced 120 REG and 15 OT across 15 days; 10 hours produced 120 REG and 30 OT across 15 days.
- Generated workbook: all visible payroll/report sheets rendered and inspected; no `#REF!`, `#DIV/0!`, `#VALUE!`, `#NAME?`, or `#N/A` errors were found.
- Final snapshot persistence on a copied MDB: passed for the summary row, day-level detail, and audit trail in one FINAL save.
- Overall payroll workbook for `1_1st_2026` on a copied MDB: 41 active main clients, 106 active detachments, four detachments with payroll, and 27 employee rows. All 27 were correctly identified as legacy recalculations because the historical test records predate the snapshot fields.
- Overall workbook sheets rendered and inspected; summary references resolve to the employee-detail totals and no Excel formula errors were found.
- Payslip OT itemization verification: OT Regular, OT Sunday, OT Legal Holiday, and OT Special Holiday displayed their individual hours and amounts; total earnings, total deductions, and net pay reconciled with no formula errors.
- DTR Exports combined-classification verification: six additive Access columns were created on a copied MDB; a 70-parameter summary write succeeded; the existing export view exposed all six fields; and standalone plus combined grid values reconstructed the original universal SH/LH, ND, and OT totals exactly.
- Excel classification-detail verification: a saved `SUN+SH` sample rendered with 8.00 `SUN + SH`, 4.00 `ND SUN + SH`, and 2.00 `OT SUN + SH`, while standalone SH/ND SH/OT SH remained zero; the fixed payroll sheet retained its established recombined columns and the workbook contained no formula errors.
- Disabled-category fallback verification: an eight-hour Sunday night shift with four overtime hours and all Sunday categories disabled routed to 8 REG, 8 ND REG, and 4 OT REG; calculated earnings matched 1,380.00 at an 800.00 daily wage.
- Sunday/holiday interaction verification: `SUN+SH` and `SUN+LH` selections remained valid, SH/LH stayed mutually exclusive, and a saved `SUN+SH` classification reloaded with both selections intact.
- Premium calculation verification on 2026-08-21 at an 800.00 daily wage: Sunday and standalone SH produced 1,040.00 for eight hours; LH produced 1,600.00; SH+rest produced 1,200.00 plus 120.00 ND and 390.00 for two OT hours; LH+rest produced 2,080.00 plus 208.00 ND and 676.00 for two OT hours.
- Legacy-policy migration verification on a copied MDB: a saved Sunday `1.30` full multiplier loaded as a `0.30` additional premium, saving wrote `ADDITIONAL_PREMIUM_V1`, and all 14 premium rules persisted.
- The older Payroll and Report Settings screen follows the same convention. Existing XML values such as `1.30` and `2.00` are converted to `0.30` and `1.00` when the file has no premium-semantics marker; the next save writes the marker and premium-named XML fields.
- Production MDB migration on 2026-08-15: added the 27 missing context/monetary snapshot columns to `Data\Database\DMSA.mdb`. The database reopened successfully, the migration passed an idempotent second run, and row counts across ten payroll/client/employee tables matched the verified pre-migration backup.

## UAT checklist

Use a backup/copy of the production MDB and representative administrator and payroll users.

1. Confirm a non-administrator cannot open payroll-rule configuration.
2. Import the supplied workbook and review the wage-difference report.
3. Verify one standard client, one disabled-category client, one OT-at-regular-rate client, one fixed-ND client, one incentive client, and both a 9-hour and 10-hour one-shift client.
4. Enter a first-cutoff manual DTR with Sunday, legal holiday, special holiday, night shift, and overtime cases.
5. Disable SUN, ND SUN, and OT SUN for a test client; select a Sunday shift and confirm the hours appear under REG, ND REG, and OT REG and remain included in gross pay.
6. Select Sunday plus SH, then Sunday plus LH. Confirm both combinations are accepted, SH and LH cannot both remain selected, and eight ordinary hours pay at 1.50 and 2.60 respectively without duplicating worked hours.
7. Save or submit those records, open DTR Exports, and confirm the hours appear in `SUN + SH` or `SUN + LH` (and the applicable combined ND/OT columns), while the standalone SH/LH columns exclude those same hours.
8. Enter multiple duties on one date and confirm payroll day units and total hours.
9. Edit first- and second-cutoff deductions and confirm ND/OT buckets remain unchanged.
10. Export payroll and compare every populated universal column, total earnings, deductions, net pay, and payslip to an independently checked result.
11. Finalize a payroll, change the client's current wage or policy in a test copy, then confirm both individual and overall exports still use the finalized saved amounts.
12. Run **Export All Active Clients** for both cutoffs. Confirm every active detachment appears in Client Coverage, drafts are excluded, each employee appears once at the latest eligible revision, the six combined-classification subset columns match Manual DTR, and the Summary totals match Employee Payroll.
13. Confirm legacy rows are visibly labeled `LEGACY RECALCULATED` and obtain payroll-owner acceptance of how historical periods will be handled.
14. Confirm the DTR-hours report still matches the daily matrix.
15. Close and restart the application, then confirm saved policies, payroll snapshots, and audit history remain available.
16. Test with the Excel rule workbook open in Excel and test an export filename already open in Excel.

## Release and rollback

Current readiness is **Not ready for production deployment**. The feature build, clean Release folder, and isolated functional checks pass, but business UAT, clean-machine deployment, installer/signing policy, and production backup ownership are not yet evidenced. The Release inventory also contains a PDB; retain or remove it according to the company symbol policy.

Before rollout:

1. Back up the MDB and application folder.
2. Retain the source workbook and the import result as release evidence.
3. Run UAT and obtain payroll-owner approval for the 77 wage differences.
4. Produce and test the company-standard Release package on a representative workstation.
5. Verify the Access provider and application process architecture.

Rollback is to restore the previous application folder and, if policies or DTR records were written after rollout, restore the coordinated MDB backup. A binary-only rollback is normally compatible with the additive tables/columns, but it will not remove policy or new DTR data.

## Known data-source gaps

`SSS Provident` is entered with the first-cutoff statutory deductions in Manual DTR and is stored with the cutoff revision. Other Earnings and Other Deductions are now entered and stored in Manual DTR. `Signature` still has no current source field and remains blank.

Historical rows created before this change do not contain finalized monetary snapshots. The overall export deliberately recalculates and labels them. A payroll-owner-approved migration source is required if those historical rows must become immutable snapshots.
