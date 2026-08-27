using AppCollRider.Services;
using AppCollRider.Guards;
using AppCollRider.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppCollRider.Controllers;

[ApiController]
[Route("api/broadband")]
public class BroadbandController : ControllerBase
{
    private readonly BroadbandService _broadbandService;

    public BroadbandController(BroadbandService broadbandService)
    {
        _broadbandService = broadbandService;
    }
    
    [HttpPost("import")]
    public async Task<IActionResult> ImportAsync()
    {
        var guid = await _broadbandService.Import();
        
        HttpContext.Session.SetString("BroadbandStateStoreGuid", guid.ToString());
        
        return Ok();
    }
    
    [RequireBroadbandData]
    [HttpGet("records")]
    public IEnumerable<BroadbandRecord> GetRecords([FromQuery] decimal maxNoInternetAccessPercentage)
    {
        if (HttpContext.Items["BroadbandStateStoreGuid"] is not Guid broadbandStateStoreGuid)
        {
            throw new Exception("The broadbandStateStoreGuid is missing.");
        }
        
        var records = _broadbandService.GetRecords(broadbandStateStoreGuid); 
            
        return records;
    }
    
    [RequireBroadbandData]
    [HttpGet("summary")]
    public IEnumerable<BroadbandRecord> GetSummary()
    {
        if (HttpContext.Items["BroadbandStateStoreGuid"] is not Guid broadbandStateStoreGuid)
        {
            throw new Exception("The broadbandStateStoreGuid is missing.");
        }
        
        var records = _broadbandService.GetRecords(broadbandStateStoreGuid);
        
        return records;
    }
    
    [RequireBroadbandData]
    [HttpGet("export")]
    public IEnumerable<BroadbandRecord> ExportAsync()
    {
        return [];
    }
    
    [RequireBroadbandData]
    [HttpPost("reset")]
    public IEnumerable<BroadbandRecord> Reset()
    {
        return [];
    }
    
    [HttpGet("status")]
    public IEnumerable<BroadbandRecord> GetStatus()
    {
        return [];
    }
}