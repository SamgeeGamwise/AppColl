using Microsoft.AspNetCore.Mvc;

namespace AppCollRider.Filters;

public sealed class RequireBroadbandDataAttribute() : TypeFilterAttribute(typeof(RequireBroadbandDataFilter));