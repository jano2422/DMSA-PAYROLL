# DMSA Payroll v1.0.4

This patch adjusts company-logo size and alignment in generated Excel reports.

- Payroll Sheet, Classification Detail, and DTR_Hours logos are approximately 1 × 1 inch and preserve the source image proportions.
- Payslip logos are approximately 0.5 × 0.5 inch and preserve the source image proportions.
- Report logos are nudged left for alignment. The larger report logos remain within the company-header area.
- Payroll data, formulas, and the remaining report formatting are unchanged.
- Application file version: **1.0.4.0**.

## Validation

- Release build succeeds with the two existing compiler warnings in the legacy HR application and DTR entry modules.
- Sample exports for both cutoffs confirm the report and payslip logo dimensions and placement.
- Release package checks confirm the executable matches the verified build and exclude payroll databases, local configuration, generated workbooks, and debug symbols.

## Installation

This release follows the existing pre-release distribution format. Organization-approved UAT, database backup ownership, workstation/provider validation, and payroll-owner sign-off remain deployment prerequisites.

The Windows ZIP contains the application, runtime dependencies, and company-logo resource. It excludes payroll databases, local settings, generated payroll workbooks, and debug symbols. Extract it into a new folder, preserve the existing installation and settings, and set `DatabasePath` in `DMSA_System.exe.config` to an authorized Access database. Do not overwrite an existing database when updating the application.

Requires Windows, .NET Framework 4.7.2, and a Microsoft Access provider compatible with the application process architecture.
