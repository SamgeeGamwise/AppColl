using AppCollRider.Services;
using AppCollRider.Guards;
using AppCollRider.Models;
using AppCollRider.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace AppCollRider.Controllers;

[ApiController]
[Route("api/broadband")]
public class BroadbandController(BroadbandService broadbandService, BroadbandSession broadbandSession) : ControllerBase
{
    [HttpPost("import")]
    public async Task<IActionResult> ImportAsync()
    {
        var broadbandStateId = broadbandSession.GetStateId();
        
        if (broadbandStateId is not null)
        {
            return BadRequest();
        }
        
        var guid = await broadbandService.Import();
        
        broadbandSession.SetBroadbandStateId(guid);
        
        return NoContent();
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
    public async Task<IActionResult> Export([FromQuery] BroadbandExportQuery query)
    {
        var data = await broadbandService.Export(query);

        return data;
    }
    
    [RequireBroadbandData]
    [HttpPost("reset")]
    public IActionResult Reset()
    {
        var broadbandStateId = broadbandSession.GetValidatedStateId();
        
        broadbandService.Reset(broadbandStateId);
        broadbandSession.ClearBroadbandStateId();
        
        return NoContent();
    }
    
    [HttpGet("status")]
    public BroadbandStatus GetStatus()
    {
        var broadbandStateId = broadbandSession.GetStateId();

        return broadbandService.GetStateStatus(broadbandStateId);
    }
}