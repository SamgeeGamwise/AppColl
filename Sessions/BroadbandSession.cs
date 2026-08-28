namespace AppCollRider.Sessions;

public sealed class BroadbandSession(IHttpContextAccessor httpContextAccessor)
{    
    public Guid? GetStateId()
    {
        var broadbandStateIdString = httpContextAccessor.HttpContext?.Session.GetString(BroadbandSessionKeys.SessionStateId);
        
        Guid? broadbandStateId = null;

        if (Guid.TryParse(broadbandStateIdString, out var parsedId))
        {
            broadbandStateId = parsedId;
        }
        
        return broadbandStateId;
    }

    public Guid GetValidatedStateId()
    {
        var broadbandStateId = httpContextAccessor.HttpContext?.Items[BroadbandSessionKeys.ValidatedSessionStateId];

        if (broadbandStateId is Guid validStateId)
        {
            return validStateId;
        }
        
        throw new Exception("Invalid state id");
    }
    
    public void SetBroadbandStateId(Guid broadbandStateId)
    {
        httpContextAccessor.HttpContext?.Session.SetString(BroadbandSessionKeys.SessionStateId, broadbandStateId.ToString());
    }

    public void ClearBroadbandStateId()
    {
        httpContextAccessor.HttpContext?.Session.Remove(BroadbandSessionKeys.SessionStateId);
        httpContextAccessor.HttpContext?.Items.Remove(BroadbandSessionKeys.ValidatedSessionStateId);
    }
}