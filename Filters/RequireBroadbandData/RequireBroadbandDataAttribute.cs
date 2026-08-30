using Microsoft.AspNetCore.Mvc;

namespace AppColl.Filters.RequireBroadbandData;

public sealed class RequireBroadbandDataAttribute() : TypeFilterAttribute(typeof(RequireBroadbandDataFilter));