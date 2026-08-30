using AppColl.Data.State;
using AppColl.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppColl.Filters.ProhibitBroadbandData;

public sealed class ProhibitBroadbandDataFilter(IBroadbandStateStore broadbandStateStore) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var broadbandStateStoreGuidString = context.HttpContext.Session.GetString(BroadbandSessionKeys.SessionStateId);

        if (Guid.TryParse(broadbandStateStoreGuidString, out var broadbandStateStoreGuid) && broadbandStateStore.Has(broadbandStateStoreGuid))
        {
            context.Result = new BadRequestObjectResult(new
            {
                error = "Broadband data already exists."
            });
      
            return;
        }
        
        await next();
    }
}