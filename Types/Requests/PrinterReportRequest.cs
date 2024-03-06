namespace PrinterManagerServer.Types.Requests;

public class PrinterReportRequest
{
    public required Guid PrinterGuid { get; set; }
    public required ReportSeverity Severity { get; set; }
    public required string Description { get; set; }
    
    public bool Resolved { get; set; }
    public DateTimeOffset? ResolveDate { get; set; }
    public string? ResolveComment { get; set; }
    public string? ResolverUsername { get; set; }
}