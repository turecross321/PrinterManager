using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrinterManagerServer.Database;
using PrinterManagerServer.Types;
using PrinterManagerServer.Types.Requests;
using PrinterManagerServer.Types.Responses;

namespace PrinterManagerServer.Controllers;

[ApiController]
[Route("printerModels")]
public class PrinterModelController: Controller
{
    [HttpGet("")]
    public IActionResult ListPrinterModels()
    {
        using DatabaseContext db = new();
        DbSet<PrinterModel> models = db.GetPrinterModels();
        IQueryable<PrinterModelResponse> responses = models.Select(m => new PrinterModelResponse(m));
        
        // todo: pagination? can't be bothered right now, and it would be unnecessary
        return Ok(new ListResponse<PrinterModelResponse>(responses));
    }
    
    [HttpPost("add")] // todo: require admin
    public IActionResult AddPrinterModel([FromBody] PrinterModelRequest request)
    {
        using DatabaseContext db = new();

        PrinterModel model = new()
        {
            Name = request.Name,
            PrintVolumeWidthMm = request.PrintAreaWidthMm,
            PrintVolumeHeightMm = request.PrintAreaHeightMm,
            PrintVolumeLengthMm = request.PrintAreaLengthMm,
            ImageUrl = request.ImageUrl,
            ReleaseDate = request.ReleaseDate
        };
        db.AddPrinterModel(model);

        return Ok(new PrinterModelResponse(model));
    }

    // todo: guid probably doesnt work
    // todo: if guid works, put it in the requests yo
    [HttpDelete("guid/{guid}")] // todo: require admin
    public IActionResult DeletePrinterModel([FromRoute] Guid guid)
    {
        using DatabaseContext db = new ();

        PrinterModel? model = db.GetPrinterModelWithGuid(guid);
        if (model == null)
            return NotFound();
        
        db.DeletePrinterModel(model);
        return Ok();
    }
}