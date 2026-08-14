# Configurable Sub-client Payroll

## Outcome

Payroll handling is now configured at the sub-client/detachment level. The client master remains the source of truth for the daily wage, while the payroll policy controls which universal pay categories are enabled and which multipliers or exceptional calculations apply.

The implementation aligns manual DTR entry, the payroll review grid, payroll export, payslips, and the DTR-hours report with the attached universal payroll workbook.

## Workbook findings

The universal template contains 46 labeled columns from `Employee Name` through `Signature`. The client-rule workbook defines the same 12 time/pay categories:

| Category | Standard multiplier |
|---|---:|
| Regular | 1.00 |
| Sunday | 1.30 |
| Legal holiday | 2.00 |
| Special holiday | 1.30 |
| ND regular | 0.10 |
| ND Sunday | 0.13 |
| ND legal holiday | 0.20 |
| ND special holiday | 0.13 |
| OT regular | 1.25 |
| OT Sunday | 1.69 |
| OT legal holiday | 2.60 |
| OT special holiday | 1.69 |

The workbook also contains client exceptions: disabled categories, overtime paid at 1.00, a fixed night-differential cutoff pool of 987.50, and a five-day incentive calculation. These are represented as policy settings instead of client-name conditions in code.

The workbook's second column also defines duty length: 71 rows use 12 hours, 13 use 8 hours, four use 10 hours, one uses 9 hours, and one uses the mixed value `8hrs/12hrs`. The 9-hour and 10-hour rows are treated as one configured shift: the first 8 hours are regular and the succeeding 1 or 2 hours are overtime.

## Configuration model

Three Access tables are created idempotently when the feature is first used:

- `PRL_SUB_CLIENT_PAY_POLICY`: one policy header per sub-client, including base hours, manual-DTR duty mode, configured single-shift hours/night flag, ND mode, incentive parameters, notes, and audit fields.
- `PRL_SUB_CLIENT_PAY_RATE`: 12 enabled/multiplier rows per sub-client.
- `PRL_SUB_CLIENT_PAY_POLICY_HISTORY`: immutable text snapshots for each save/import.

`OT_SUN`, `OT_LH`, and `OT_SH` are added to `PRL_DTR_TOTAL_HOURS`. Existing ND columns and `OT_REG` are retained.

Precedence is deliberately simple: a saved sub-client policy is used when present; otherwise the standard universal policy is used. There is no hidden client-name override.

## Administrator workflow

1. Open **Payroll rules** from Manual DTR or Payroll Exports.
2. Select the main client and sub-client.
3. Enable or disable each universal category and set its multiplier.
4. Choose whether Manual DTR follows the client schedule or uses one configured shift. For one shift, enter the total duty hours and whether it is a night shift.
5. Select ND hours, monthly ND paid by reporting days, or disabled night differential.
6. Configure the optional five-day incentive and add an explanation in Notes.
7. Save. The change is timestamped and recorded with the current user.

The **Import Excel rules** action reads `Sheet3` from the supplied client-rule workbook. Matching is based on normalized sub-client name plus location aliases when the database contains duplicate generic names. Rows containing a single 9-hour or 10-hour value automatically enable one-shift mode. The import does not update daily wage or the client-master schedule type.

## DTR and export behavior

- Manual DTR shows REG, SUN, LH, SH, four ND buckets, and four OT buckets in the same order used by the universal sheet.
- Sunday remains an explicit classification on actual Sundays; Sunday, legal holiday, and special holiday are mutually exclusive for a date.
- Each selected duty is one reporting day, even when several duties are selected on the same calendar date. For example, all three tri-shifts count as three reporting days; both 12-hour shifts count as two reporting days and total 24 hours.
- A configured one-shift duty always produces one reporting day. A 9-hour shift produces 8 REG and 1 OT; a 10-hour shift produces 8 REG and 2 OT. Sunday/holiday classification moves both portions into the corresponding SUN/LH/SH and OT SUN/OT LH/OT SH buckets.
- Payroll Exports shows all universal hour buckets with frozen employee columns and horizontal scrolling.
- For a monthly ND amount, the calculation uses the selected-shift reporting-day count. It does not derive days from total working hours.
- The generated workbook contains `PAYROLL SHEET`, `PAYSLIP`, `DTR_Hours`, and a very-hidden `SETTINGS` sheet. The payroll sheet uses the exact 46-column template order and policy-driven formulas.
- The deduction-update earnings preview uses the same sub-client policy as the export. Saving deductions preserves the extended ND and OT buckets.

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
- Generated workbook: all four sheets rendered and inspected; no `#REF!`, `#DIV/0!`, `#VALUE!`, `#NAME?`, or `#N/A` errors were found.

## UAT checklist

Use a backup/copy of the production MDB and representative administrator and payroll users.

1. Confirm a non-administrator cannot open payroll-rule configuration.
2. Import the supplied workbook and review the wage-difference report.
3. Verify one standard client, one disabled-category client, one OT-at-regular-rate client, one fixed-ND client, one incentive client, and both a 9-hour and 10-hour one-shift client.
4. Enter a first-cutoff manual DTR with Sunday, legal holiday, special holiday, night shift, and overtime cases.
5. Enter multiple duties on one date and confirm payroll day units and total hours.
6. Edit first- and second-cutoff deductions and confirm ND/OT buckets remain unchanged.
7. Export payroll and compare every populated universal column, total earnings, deductions, net pay, and payslip to an independently checked result.
8. Confirm the DTR-hours report still matches the daily matrix.
9. Close and restart the application, then confirm saved policies and audit history remain available.
10. Test with the Excel rule workbook open in Excel.

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

The template columns `SSS Provident`, `Other Earnings`, `Other Deductions`, and `Signature` have no current source fields in the application. They are present in the export and currently remain zero/blank until those data-entry requirements are defined.
