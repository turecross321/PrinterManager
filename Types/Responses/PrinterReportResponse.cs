namespace PrinterManagerServer.Types.Responses;

public class PrinterReportResponse(PrinterReport report)
{
    public Guid Guid { get; set; } = report.Guid;
    public PrinterResponse Printer { get; set; } = new(report.Printer, null);
    public ReportSeverity Severity { get; set; } = report.Severity;
    public string Description { get; set; } = report.Description;
    public DateTimeOffset CreationDate { get; set; } = report.CreationDate;
    
    public bool Resolved { get; set; } = report.Resolved;
    public DateTimeOffset? ResolveDate { get; set; } = report.ResolveDate;
    public string? ResolveComment { get; set; } = report.ResolveComment;
    public User? Resolver { get; set; } = report.Resolver;
}