using System.Text.Json.Serialization;

namespace AppCollRider.Enums;

public enum BroadbandConnectionLevel
{
    [JsonStringEnumMemberName("Low Connected")]
    LowConnected,

    [JsonStringEnumMemberName("Medium Low Connected")]
    MediumLowConnected,

    [JsonStringEnumMemberName("Medium Connected")]
    MediumConnected,

    [JsonStringEnumMemberName("Medium High Connected")]
    MediumHighConnected,

    [JsonStringEnumMemberName("High Connected")]
    HighConnected
}