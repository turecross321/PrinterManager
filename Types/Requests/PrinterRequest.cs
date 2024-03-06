namespace PrinterManagerServer.Types.Requests;

public class PrinterRequest
{
    public required int Number { get; set; }
    public required Guid ModelGuid { get; set; }
    public required bool Active { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
}