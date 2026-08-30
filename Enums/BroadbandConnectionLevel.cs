using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace AppColl.Enums;

public enum BroadbandConnectionLevel
{
    [JsonStringEnumMemberName("Low Connected")]
    [XmlEnum("Low Connected")]
    LowConnected,

    [JsonStringEnumMemberName("Medium Low Connected")]
    [XmlEnum("Medium Low Connected")]
    MediumLowConnected,

    [JsonStringEnumMemberName("Medium Connected")]
    [XmlEnum("Medium Connected")]
    MediumConnected,

    [JsonStringEnumMemberName("Medium High Connected")]
    [XmlEnum("Medium High Connected")]
    MediumHighConnected,

    [JsonStringEnumMemberName("High Connected")]
    [XmlEnum("High Connected")]
    HighConnected
}