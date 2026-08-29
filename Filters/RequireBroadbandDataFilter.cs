using AppCollRider.Sessions;
using AppCollRider.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCollRider.Filters;

public sealed class RequireBroadbandDataFilter(IBroadbandStateStore broadbandStateStore) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var broadbandStateStoreGuidString = context.HttpContext.Session.GetString(BroadbandSessionKeys.SessionStateId);

        if (!Guid.TryParse(broadbandStateStoreGuidString, out var broadbandStateStoreGuid) || !broadbandStateStore.Has(broadbandStateStoreGuid))
        {
            context.Result = new BadRequestObjectResult(new
            {
                error = "Broadband data not yet imported or session expired."
            });
      
            return;
        }
    
        context.HttpContext.Items[BroadbandSessionKeys.ValidatedSessionStateId] = broadbandStateStoreGuid;
    
        await next();
    }
}