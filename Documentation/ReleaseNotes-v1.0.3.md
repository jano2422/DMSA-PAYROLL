# DMSA Payroll v1.0.3

This patch release improves Manual DTR contribution entry and Excel report readability and printing.

- Manual DTR's **Previous month** button copies the selected employee/client's SSS, SSS Provident, PhilHealth, and Pag-IBIG contributions from the same cutoff last month. It previews the amounts, replaces only those contributions, and leaves them unsaved until the user saves or submits. Existing first-cutoff rules and final-record locks apply.
- Excel company logos sit beside the company details on each report and payslip block.
- Reports use larger text, wrapped details, compact columns, and row heights that accommodate long names and addresses.
- Payslips keep their taller worksheet rows and print four employees per A4 page, in two columns and two rows. Eight employees print on two pages. Print scaling accommodates the tallest group of four, and page breaks fall between employee groups.
- The payroll sheet opens in Page Break Preview, with every column through Signature inside the print area and fitted to one landscape page wide. Further employee rows continue downward.
- Payroll and Report Settings now contains company identity and signatories only. Calculation rules remain in the per-sub-client payroll settings. Existing company/signatory XML settings are retained, and obsolete global calculation fields are ignored.
- Application file version: **1.0.3.0**.

## Validation

- Release build succeeds with the two existing compiler warnings in the legacy HR application and DTR entry modules.
- Manual DTR checks cover 37 assertions without connecting to or writing a payroll database.
- Settings smoke checks cover legacy XML loading, company/signatory round-tripping, validation, and removal of the obsolete calculation tab.
- Sample export comparisons confirm preserved values and formulas for both cutoffs and overall payroll reports.
- Excel's print engine verified eight employee payslips on two pages for both cutoffs. Saved export checks confirm the complete payroll print range, one-page width, and Page Break Preview.

## Installation

This release follows the existing pre-release distribution format. Organization-approved UAT, database backup ownership, workstation/provider validation, and payroll-owner sign-off remain deployment prerequisites.

The Windows ZIP contains the application, runtime dependencies, and company-logo resource. It excludes payroll databases, local settings, generated payroll workbooks, and debug symbols. Extract it into a new folder, preserve the existing installation and settings, and set `DatabasePath` in `DMSA_System.exe.config` to an authorized Access database. Do not overwrite an existing database when updating the application.

Requires Windows, .NET Framework 4.7.2, and a Microsoft Access provider compatible with the application process architecture.
