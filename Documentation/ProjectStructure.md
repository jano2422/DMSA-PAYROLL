# Project Structure

This project is a Visual Basic .NET Framework WinForms payroll application. Keep the root directory limited to solution/project files and application-level configuration.

## Root

- `DMSA_System.sln`, `DMSA_System.vbproj`: Visual Studio solution and project files.
- `App.config`: application configuration.
- `My Project/`: Visual Basic project-generated files. Do not move this folder.

## Source Code

- `Forms/`: WinForms screens, dialogs, designer files, and `.resx` files. Group forms by the main navigation first, then by business capability.
  - `Forms/Authentication/`: login, password change, and user management.
  - `Forms/HumanResources/`: applicants, employee records, employee updates, HR reports, and HR-owned subareas.
  - `Forms/HumanResources/Clients/`: client registration, maintenance, and deactivation shown from the Human Resources menu.
  - `Forms/Payroll/`: payroll-specific forms such as loans.
  - `Forms/Payroll/Timekeeping/`: DTR, biometric import, deductions, reports, relievers, and payroll exports shown from the Payroll System menu.
  - `Forms/Operations/`: operations-specific screens.
  - `Forms/Operations/Scheduling/`: schedule screens shown from the Operations menu.
  - `Forms/Shell/`: main shell/window forms.
  - `Forms/Common/`: shared dialogs and utility forms.
  - `Forms/Approvals/`: approval workflow forms.
- `Modules/`: legacy VB modules and shared procedural helpers. Mirror the form feature folders when a module belongs to one area, such as `Modules/HumanResources/Clients/` or `Modules/Payroll/Timekeeping/`.
- `Services/`: service classes with reusable business logic.
- `Models/`: data models and simple DTO-style classes.

## Assets And Data

- `Resources/`: image and application resources referenced by `My Project/Resources.resx`.
- `Reports/`: RDLC and report definition files.
- `Lib/`: vendored third-party binaries that are not restored by NuGet.
- `Data/Database/`: seed/local database files that should be copied to the build output.
- `Data/Samples/`: sample input files used for development or testing.
- `DatabaseBackups/`: historical MDB backups, not active runtime data.

## Supporting Files

- `Documentation/`: project notes and setup guidance.
- `Archive/`: historical generated files or old backups kept only for reference.

Do not commit build output (`bin/`, `obj/`), Visual Studio state (`.vs/`), generated exports, or temporary scratch files.
