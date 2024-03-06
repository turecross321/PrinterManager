using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using PrinterManagerServer.Types;
using PrinterManagerServer.Types.Requests;
using PrinterManagerServer.Types.Responses;

namespace PrinterManagerServer.Database;

public partial class DatabaseContext
{
    public DbSet<PrinterReport> GetPrinterReports() => PrinterReports;
    public PrinterReport? GetPrinterReportWithGuid(Guid guid) => PrinterReports.FirstOrDefault(r => r.Guid == guid);

    public void AddPrinterReport(PrinterReport report)
    {
        PrinterReports.Add(report);
        SaveChanges();
    }

    public void DeletePrinterReport(PrinterReport report)
    {
        PrinterReports.Remove(report);
        SaveChanges();
    }

    public PrinterReport EditPrinterReport(PrinterReport report, PrinterReportRequest edit)
    {
        report.Severity = edit.Severity;
        report.Description = edit.Description;
        report.Resolved = edit.Resolved;
        report.ResolveComment = edit.ResolveComment;
        report.ResolveDate = edit.ResolveDate;
        if (edit.ResolverUsername != null)
            report.Resolver = GetUserWithUsername(edit.ResolverUsername);
        
        SaveChanges();

        return report;
    }

}