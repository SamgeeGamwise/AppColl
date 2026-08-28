using Microsoft.AspNetCore.Mvc;

namespace AppCollRider.Guards;

public sealed class RequireBroadbandDataAttribute() : TypeFilterAttribute(typeof(RequireBroadbandDataFilter));