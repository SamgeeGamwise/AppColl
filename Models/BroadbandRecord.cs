using System.Text.Json.Serialization;
using System.Xml.Serialization;
using AppCollRider.Enums;

namespace AppCollRider.Models;

public sealed class BroadbandRecord
{
[JsonPropertyName("oid")]
    [XmlElement("oid")]
    public int Oid { get; init; }

    [JsonPropertyName("zip_code")]
    [XmlElement("zip_code")]
    public string ZipCode { get; init; } = string.Empty;

    [JsonPropertyName("home_broadband_adoption")]
    [XmlElement("home_broadband_adoption")]
    public decimal HomeBroadbandAdoption { get; init; }

    [JsonPropertyName("mobile_broadband_adoption")]
    [XmlElement("mobile_broadband_adoption")]
    public decimal MobileBroadbandAdoption { get; init; }

    [JsonPropertyName("no_internet_access_percentage")]
    [XmlElement("no_internet_access_percentage")]
    public decimal NoInternetAccessPercentage { get; init; }

    [JsonPropertyName("no_home_broadband_adoption")]
    [XmlElement("no_home_broadband_adoption")]
    public decimal NoHomeBroadbandAdoption { get; init; }

    [JsonPropertyName("no_mobile_broadband_adoption")]
    [XmlElement("no_mobile_broadband_adoption")]
    public decimal NoMobileBroadbandAdoption { get; init; }

    [JsonPropertyName("no_home_broadband_adoption_1")]
    [XmlElement("no_home_broadband_adoption_1")]
    public BroadbandConnectionLevel NoHomeBroadbandAdoptionLevel { get; init; }

    [JsonPropertyName("no_mobile_broadband_adoption_1")]
    [XmlElement("no_mobile_broadband_adoption_1")]
    public BroadbandConnectionLevel NoMobileBroadbandAdoptionLevel { get; init; }

    [JsonPropertyName("commercial_fiber_max_isp")]
    [XmlElement("commercial_fiber_max_isp")]
    public int CommercialFiberMaxIsp { get; init; }

    [JsonPropertyName("public_computer_center_count")]
    [XmlElement("public_computer_center_count")]
    public int PublicComputerCenterCount { get; init; }

    [JsonPropertyName("workstations_in_pccs")]
    [XmlElement("workstations_in_pccs")]
    public int WorkstationsInPccs { get; init; }

    [JsonPropertyName("avg_training_hrs_per_week")]
    [XmlElement("avg_training_hrs_per_week")]
    public decimal AverageTrainingHoursPerWeek { get; init; }

    [JsonPropertyName("public_wi_fi_count")]
    [XmlElement("public_wi_fi_count")]
    public int PublicWiFiCount { get; init; }

    [JsonPropertyName("poles_reserved_by_mobile")]
    [XmlElement("poles_reserved_by_mobile")]
    public int PolesReservedByMobile { get; init; }

    [JsonPropertyName("pole_with_equipment_installed")]
    [XmlElement("pole_with_equipment_installed")]
    public int PolesWithEquipmentInstalled { get; init; }

    [JsonPropertyName("density_of_poles_reserved")]
    [XmlElement("density_of_poles_reserved")]
    public decimal DensityOfPolesReserved { get; init; }
}