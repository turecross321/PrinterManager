namespace PrinterManagerServer.Types.Responses;

public class PrinterModelResponse(PrinterModel model)
{
    public Guid Guid { get; set; } = model.Guid;
    public string Name { get; set; } = model.Name;
    public float PrintAreaWidthMm { get; set; } = model.PrintVolumeWidthMm;
    public float PrintAreaHeightMm { get; set; } = model.PrintVolumeHeightMm;
    public float PrintAreaLengthMm { get; set; } = model.PrintVolumeLengthMm;
    public string ImageUrl { get; set; } = model.ImageUrl;
    public DateTimeOffset ReleaseDate { get; set; } = model.ReleaseDate;
}