# DMSA Payroll System

![DMSA logo](Resources/DMSA_Logo.png)

DMSA Payroll System is an internal Windows desktop application for employee records, client and detachment management, scheduling, daily time records (DTR), payroll preparation, and Excel reporting.

The application is written in Visual Basic .NET using Windows Forms and targets .NET Framework 4.7.2. It stores operational data in a Microsoft Access (`.mdb`) database and creates payroll workbooks with ClosedXML and the Open XML SDK.

## Main capabilities

- User authentication, password management, and activity logging
- Applicant and employee record management
- Main-client and sub-client/detachment administration
- Employee scheduling and assignment
- Manual DTR entry with draft, amendment, finalization, and audit history
- Configurable payroll policies per sub-client
- Payroll preview, deductions, allowances, incentives, and payslips
- Individual-client and all-active-client Excel exports
- DTR-hours and payroll reports

## Manual DTR and payroll classifications

Manual DTR records worked hours once and classifies them into the applicable pay category:

| Classification | Default additional premium | Effective day factor |
|---|---:|---:|
| Regular | 0.00 | 1.00 |
| Sunday | 0.30 | 1.30 |
| Special holiday | 0.30 | 1.30 |
| Legal holiday | 1.00 | 2.00 |
| Sunday + special holiday | 0.50 | 1.50 |
| Sunday + legal holiday | 1.60 | 2.60 |

Payroll settings use **additional premiums**. For example, enter `0.30` to add 30%; do not enter `1.30`. Existing legacy full-factor settings are normalized when loaded.

Sunday can be combined with either Special Holiday or Legal Holiday. Special Holiday and Legal Holiday remain mutually exclusive. The Manual DTR breakdown and export detail show `SUN + SH` and `SUN + LH` separately, including their night-differential and overtime variants, without duplicating total worked hours.

Manual DTR can copy SSS (including Provident), PhilHealth, and Pag-IBIG contributions from the previous month into an editable 1st-cutoff client workspace. See [Copying benefits](Documentation/ManualDtrBenefitCopy.md) for source selection, confirmation, and verification details.

## Excel exports

An individual-client payroll workbook contains:

- `PAYROLL SHEET` — the established 46-column payroll template
- `CLASSIFICATION DETAIL` — standalone Sunday/holiday and combined Sunday+holiday hours
- `PAYSLIP` — employee payslips with itemized overtime
- `DTR_Hours` — detailed DTR-hour data
- `SETTINGS` — a very-hidden worksheet used by workbook formulas

Payslips separate overtime into Regular, Sunday, Legal Holiday, and Special Holiday hours and amounts. The all-active-client export also separates standalone holiday hours from the `SUN + SH` and `SUN + LH` classifications while preserving historical payroll totals.

Exports wrap long names, labels, and addresses and use larger report text. Company logos sit beside the company details. Payslips print four employees per A4 page (two across and two down), with the taller worksheet layout scaled for printing. The payroll sheet opens in Page Break Preview with all columns through Signature inside the print area, fitted to one landscape page wide; additional employee rows continue on pages below.

## Requirements

- Windows
- Visual Studio 2019 or later with the **.NET desktop development** workload
- .NET Framework 4.7.2 Developer Pack
- A compatible Microsoft Access provider, preferably Microsoft Access Database Engine (ACE) 12.0 or 16.0
- Access to the authorized DMSA payroll database

The installed Access provider architecture must be compatible with the application process architecture. If the application cannot open the database, verify the installed ACE/Jet provider before changing application code.

## Local setup

1. Clone the repository.
2. Open `DMSA_System.sln` in Visual Studio.
3. Restore NuGet packages.
4. Back up the database before running a new build against production data.
5. Set `DatabasePath` in `App.config` if the database is not located at `Data\Database\DMSA.mdb`.
6. Build and run the solution.

`DatabasePath` may be relative to the executable or an absolute path such as a secured network location. Do not commit production credentials, generated exports, or database backups.

### Command-line build

Run from a Visual Studio Developer PowerShell session:

```powershell
msbuild DMSA_System.sln /restore /p:Configuration=Release
```

The output is written to `bin\Release`.

## Database updates

At login, the application performs an idempotent schema check for the payroll-policy, snapshot, audit, and combined Sunday/holiday fields required by the current build. Missing additive tables, columns, and indexes are created silently. An already-current database is left unchanged.

Always create and verify a database backup before deploying a new build. If startup migration fails, login is stopped and a diagnostic is written to:

```text
%LOCALAPPDATA%\DMSA Payroll\Logs\startup-schema.log
```

## Project structure

```text
Forms/          Windows Forms screens and dialogs
Modules/        Shared and legacy procedural modules
Services/       Payroll, policy, export, scheduling, and client logic
Models/         Data-transfer and calculation models
Reports/        Report definitions
Resources/      Images and application assets
Data/Database/  Local or seed Access database
Documentation/  Design, configuration, UAT, and release notes
```

See [Project Structure](Documentation/ProjectStructure.md) for the full directory convention.

## Documentation

- [Configurable Sub-client Payroll](Documentation/PayrollSubClientConfiguration.md) — policy rules, Manual DTR behavior, exports, verification evidence, UAT, and rollback
- [Project Structure](Documentation/ProjectStructure.md) — source and asset organization

## Deployment status

The current codebase builds and its payroll/export scenarios have been verified against database copies. Production deployment still requires organization-approved UAT, database backup ownership, workstation/provider validation, packaging, and payroll-owner sign-off. Review the release and rollback guidance before rollout.

## Data handling

This repository contains payroll and HR application code. Treat databases, exported workbooks, logs, employee information, and backups as confidential company data. Use sanitized test copies for development and troubleshooting.
