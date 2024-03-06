using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinterManagerServer.Types;

public class PrinterReport
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Guid { get; set; }
    public required Printer Printer { get; set; }
    public required ReportSeverity Severity { get; set; }
    public required string Description { get; set; }
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    
    public bool Resolved { get; set; }
    public DateTimeOffset? ResolveDate { get; set; }
    public string? ResolveComment { get; set; }
    public User? Resolver { get; set; }
}