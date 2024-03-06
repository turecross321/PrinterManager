using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PrinterManagerServer.Database;
using PrinterManagerServer.Types;
using PrinterManagerServer.Types.Requests;
using PrinterManagerServer.Types.Responses;

namespace PrinterManagerServer.Controllers;

[ApiController]
[Route("printerReports")]
public class PrinterReportController: Controller
{
    [HttpGet("")]
    public IActionResult GetReports([FromQuery] Guid? printerGuid, [FromQuery] bool? resolved)
    {
        using DatabaseContext db = new();

        IQueryable<PrinterReport> reports = db.GetPrinterReports();
        if (printerGuid != null)
            reports = reports.Where(r => r.Printer.Guid == printerGuid);
        if (resolved != null)
            reports = reports.Where(r => r.Resolved == resolved);

        IIncludableQueryable<PrinterReport, PrinterModel> selected = reports
            .Include(r => r.Printer)
            .ThenInclude(p => p.Model);
            
        IQueryable<PrinterReportResponse> responses = selected.Select(r => new PrinterReportResponse(r));
        return Ok(new ListResponse<PrinterReportResponse>(responses));
    }
    
    [HttpPost("add")]
    public IActionResult AddReport([FromBody] PrinterReportRequest request)
    {
        using DatabaseContext db = new();

        Printer? printer = db.GetPrinterWithGuid(request.PrinterGuid);
        if (printer == null)
            return NotFound();

        PrinterReport report = new()
        {
            Printer = printer,
            Severity = request.Severity,
            Description = request.Description
        };
        db.AddPrinterReport(report);

        return Ok(report);
    }

    [HttpDelete("guid/{guid}")] // todo: require admin
    public IActionResult DeleteReport([FromRoute] Guid guid)
    {
        using DatabaseContext db = new();

        PrinterReport? report = db.GetPrinterReportWithGuid(guid);
        if (report == null)
            return NotFound();
        
        db.DeletePrinterReport(report);
        return Ok();
    }
    
    // todo: require admin
    [HttpPost("guid/{guid}/edit")]
    public IActionResult EditReport([FromRoute] Guid guid, [FromBody] PrinterReportRequest request)
    {
        using DatabaseContext db = new();

        PrinterReport? report = db.GetPrinterReportWithGuid(guid);
        if (report == null)
            return NotFound();

        report = db.EditPrinterReport(report, request);
        return Ok(report);
    }
}