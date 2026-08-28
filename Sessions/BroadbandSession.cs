namespace AppCollRider.Sessions;

public sealed class BroadbandSession(IHttpContextAccessor httpContextAccessor)
{    
    private const string StateSessionIdKey = "BroadbandSessions";

    public Guid? GetStateId()
    {
        var broadbandStateIdString = httpContextAccessor.HttpContext?.Session.GetString(StateSessionIdKey);
        
        Guid? broadbandStateId = null;

        if (Guid.TryParse(broadbandStateIdString, out var parsedId))
        {
            broadbandStateId = parsedId;
        }
        
        return broadbandStateId;
    }

    public Guid GetValidStateId()
    {
        var broadbandStateId = httpContextAccessor.HttpContext?.Items[StateSessionIdKey];

        if (broadbandStateId is Guid validStateId)
        {
            return validStateId;
        }
        
        throw new Exception("Invalid state id");
    }
    
    public void SetBroadbandStateId(Guid broadbandStateId)
    {
        httpContextAccessor.HttpContext?.Session.SetString(StateSessionIdKey, broadbandStateId.ToString());
    }

    public void ClearBroadbandStateId()
    {
        httpContextAccessor.HttpContext?.Session.Remove(StateSessionIdKey);
    }
}