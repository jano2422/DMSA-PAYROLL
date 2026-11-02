# Copying benefits in Manual DTR

The **Allowances and Deductions** area has a **Previous month** button for the selected employee and client workspace.

**Previous month** uses the same cutoff in the preceding calendar month. For example, `1_1st_2026` uses `12_1st_2025`.

The source is the latest saved record for the employee's current home detachment and the exact source period. Within that record, only the selected client's contributions are used. The confirmation shows the source period, saved record status, destination period, and all four amounts. A saved draft can be a source; unsaved screen values cannot.

Only SSS contribution, SSS Provident, PhilHealth, and Pag-IBIG contribution are copied. Allowances, loans, other deductions, shifts, wages, and other client workspaces retain their current values. Copying replaces contributions rather than adding to them; zero source amounts also replace existing amounts after confirmation. If no matching saved record or client adjustment exists, the form displays a message and retains the current inputs.

Existing payroll rules apply statutory contributions in the **1st cutoff only**, so this button is disabled in the 2nd cutoff. It is available in new records, drafts, and an explicitly opened amendment draft. Submitted finals, legacy finals, and records that failed to load remain locked.

Copying changes the screen only and refreshes the payroll preview. Review the amounts and use **Save Draft**, **Save Amendment**, or the applicable submission button to persist them. Closing or changing periods still uses the existing unsaved-changes prompt.

## Verification

Build the Release solution, then run this command in Windows PowerShell 5.1 with an STA thread:

```powershell
powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File C:\Dev\DMSA-PAYROLL\Tests\ManualDtrBenefitCopy.Tests.ps1
```

The tests instantiate the actual form using design-time fixtures and an invalid database connection string. They cover source-period rollover, contribution-only replacement, repeated copying, other-client isolation, shift preservation, draft adjustment serialization/reloading, final locks, amendment access, missing/wrong-client data, zero amounts, and 2nd-cutoff restrictions without database writes. The optional `-PreviewPath` parameter renders a sample form to a PNG. Source retrieval and persistence use the existing record service; these tests do not run live database or interactive confirmation scenarios.
