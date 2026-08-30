using Microsoft.AspNetCore.Mvc;

namespace AppColl.Filters.ProhibitBroadbandData;

public sealed class ProhibitBroadbandDataAttribute() : TypeFilterAttribute(typeof(ProhibitBroadbandDataFilter));