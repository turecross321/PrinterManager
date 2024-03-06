using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinterManagerServer.Types;

public class Printer
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Guid { get; set; }
    public required int Number { get; set; }
    public required PrinterModel Model { get; set; }
    public bool Disabled { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
}