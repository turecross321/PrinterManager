using Microsoft.EntityFrameworkCore;
using PrinterManagerServer.Types;

namespace PrinterManagerServer.Database;

public partial class DatabaseContext
{
    public DbSet<PrinterModel> GetPrinterModels() => PrinterModels;
    public PrinterModel? GetPrinterModelWithGuid(Guid guid) => PrinterModels.FirstOrDefault(m => m.Guid == guid); 
    
    public void AddPrinterModel(PrinterModel model)
    {
        PrinterModels.Add(model);
        SaveChanges();
    }

    public void DeletePrinterModel(PrinterModel model)
    {
        foreach (Printer printer in Printers.Where(p => p.Model == model))
        {
            DeletePrinter(printer);
        }
        
        PrinterModels.Remove(model);
        SaveChanges();
    }
}