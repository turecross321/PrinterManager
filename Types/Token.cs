using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinterManagerServer.Types;

public class Token
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Guid { get; set; }
    public required User User { get; set; }
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public required DateTimeOffset ExpiryDate { get; set; }
    public required TokenType TokenType { get; set; }
}