using Microsoft.EntityFrameworkCore;
using PrinterManagerServer.Types;

namespace PrinterManagerServer.Database;

public partial class DatabaseContext
{
    public DbSet<Printer> GetPrinters() => Printers;
    public Printer? GetPrinterWithGuid(Guid guid) => Printers.FirstOrDefault(p => p.Guid == guid);
    public void AddPrinter(Printer printer)
    {
        Printers.Add(printer);
        SaveChanges();
    }

    public void DeletePrinter(Printer printer)
    {
        foreach (PrinterReport report in PrinterReports)
        {
            DeletePrinterReport(report);
        }
        
        Printers.Remove(printer);
        SaveChanges();
    }

    public void SetPrinterStatus(Printer printer, bool active)
    {
        printer.Disabled = active;
        SaveChanges();
    }
}