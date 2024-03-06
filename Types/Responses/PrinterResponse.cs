namespace PrinterManagerServer.Types.Responses;

public class PrinterResponse(Printer printer, bool? activeReports)
{
    public Guid Guid { get; set; } = printer.Guid;
    public int Number { get; set; } = printer.Number;
    public PrinterModelResponse Model { get; set; } = new (printer.Model);

    public bool Disabled { get; set; }
    public bool? ActiveReports { get; set; } = activeReports;
    
    public DateTimeOffset PurchaseDate { get; set; } = printer.PurchaseDate;
}