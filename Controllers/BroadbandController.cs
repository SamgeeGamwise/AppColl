using AppColl.Filters.ProhibitBroadbandData;
using AppColl.Filters.RequireBroadbandData;
using AppColl.Models;
using AppColl.Models.Requests;
using AppColl.Models.Responses;
using AppColl.Services;
using AppColl.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace AppColl.Controllers;

[ApiController]
[Route("api/broadband")]
public class BroadbandController(BroadbandService broadbandService, BroadbandSession broadbandSession) : ControllerBase
{
    [ProhibitBroadbandData]
    [HttpPost("import")]
    public async Task<BroadbandStatus> ImportAsync()
    {
        var guid = await broadbandService.Import();
        
        broadbandSession.SetBroadbandStateId(guid);

        return broadbandService.GetStateStatus(guid);
    }
    
    [RequireBroadbandData]
    [HttpGet("records")]
    public IEnumerable<BroadbandRecord> GetRecords([FromQuery] BroadbandRecordQuery recordQuery)
    {
        var broadbandStateId = broadbandSession.GetValidatedStateId();
        var records = broadbandService.GetRecords(broadbandStateId, recordQuery); 
            
        return records;
    }
    
    [RequireBroadbandData]
    [HttpGet("summary")]
    public BroadbandSummary GetSummary([FromQuery] BroadbandRecordQuery query)
    {
        var broadbandStateId = broadbandSession.GetValidatedStateId();
        var summary = broadbandService.GetSummary(broadbandStateId, query);
        
        return summary;
    }
    
    [RequireBroadbandData]
    [HttpGet("export")]
    public IActionResult Export([FromQuery] BroadbandExportQuery exportQuery, [FromQuery] BroadbandRecordQuery recordQuery)
    {
        var broadbandStateId = broadbandSession.GetValidatedStateId();
        var exportFile = broadbandService.Export(broadbandStateId, exportQuery, recordQuery);

        return File(exportFile.Content, exportFile.ContentType, exportFile.FileName);
    }
    
    [RequireBroadbandData]
    [HttpPost("reset")]
    public BroadbandStatus Reset()
    {
        var broadbandStateId = broadbandSession.GetValidatedStateId();
        
        broadbandService.Reset(broadbandStateId);
        broadbandSession.ClearBroadbandStateId();
        
        return broadbandService.GetStateStatus(null);
    }
    
    [HttpGet("status")]
    public BroadbandStatus GetStatus()
    {
        var broadbandStateId = broadbandSession.GetStateId();

        return broadbandService.GetStateStatus(broadbandStateId);
    }
}