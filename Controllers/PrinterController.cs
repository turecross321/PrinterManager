using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PrinterManagerServer.Database;
using PrinterManagerServer.Types;
using PrinterManagerServer.Types.Requests;
using PrinterManagerServer.Types.Responses;

namespace PrinterManagerServer.Controllers;

[ApiController]
[Route("printers")]
public class PrinterController: Controller
{
    [HttpGet("")]
    public IActionResult ListPrinters()
    {
        using DatabaseContext db = new();
        
        IIncludableQueryable<Printer, PrinterModel> printers = db.GetPrinters().Include(p => p.Model);
        IIncludableQueryable<PrinterReport, Printer> activeReports = db.GetPrinterReports()
            .Where(r => !r.Resolved)
            .Include(r => r.Printer);
        
        IQueryable<PrinterResponse> responses = printers
            .Select(p => new PrinterResponse(p, activeReports.Any(r => r.Printer == p)));
        
        return Ok(new ListResponse<PrinterResponse>(responses));
    }
    
    [HttpPost("add")] // todo: require admin
    public IActionResult AddPrinter([FromBody] PrinterRequest request)
    {
        using DatabaseContext db = new();

        PrinterModel? model = db.GetPrinterModelWithGuid(request.ModelGuid);
        if (model == null)
            return NotFound();

        Printer printer = new()
        {
            Number = request.Number,
            Model = model,
            Disabled = request.Active,
            PurchaseDate = request.PurchaseDate
        };
        db.AddPrinter(printer);

        return Ok(new PrinterResponse(printer, false));
    }

    [HttpDelete("guid/{guid}")] // todo: require admin
    public IActionResult DeletePrinter([FromRoute] Guid guid)
    {
        using DatabaseContext db = new();
        
        Printer? printer = db.GetPrinterWithGuid(guid);
        if (printer == null)
            return NotFound();
        
        db.DeletePrinter(printer);
        return Ok();
    }
}