using AppCollRider.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCollRider.Guards;

public sealed class RequireBroadbandDataFilter : IAsyncActionFilter
{
    private readonly IBroadbandStateStore _broadbandStateStore;

    public RequireBroadbandDataFilter(IBroadbandStateStore broadbandStateStore)
    {
        _broadbandStateStore = broadbandStateStore;
    }
  
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var broadbandStateStoreGuidString = context.HttpContext.Session.GetString("BroadbandStateStoreGuid");

        if (!Guid.TryParse(broadbandStateStoreGuidString, out var broadbandStateStoreGuid) || !_broadbandStateStore.Has(broadbandStateStoreGuid))
        {
            context.Result = new BadRequestObjectResult(new
            {
                error = "Broadband data not yet imported or session expired."
            });
      
            return;
        }
    
        context.HttpContext.Items["BroadbandStateStoreGuid"] = broadbandStateStoreGuid;
    
        await next();
    }
}