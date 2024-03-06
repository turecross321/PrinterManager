using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinterManagerServer.Types;

public class PrinterModel
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Guid { get; set; }
    public required string Name { get; set; }
    public required float PrintVolumeWidthMm { get; set; }
    public required float PrintVolumeHeightMm { get; set; }
    public required float PrintVolumeLengthMm { get; set; }
    public required string ImageUrl { get; set; }
    public required DateTimeOffset ReleaseDate { get; set; }
}