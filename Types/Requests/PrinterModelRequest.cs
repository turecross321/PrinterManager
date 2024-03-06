namespace PrinterManagerServer.Types.Requests;

public class PrinterModelRequest
{
    public required string Name { get; set; }
    public required float PrintAreaWidthMm { get; set; }
    public required float PrintAreaHeightMm { get; set; }
    public required float PrintAreaLengthMm { get; set; }
    public required string ImageUrl { get; set; }
    public required DateTimeOffset ReleaseDate { get; set; }
}