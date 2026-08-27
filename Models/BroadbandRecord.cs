using AppCollRider.Enums;

namespace AppCollRider.Models;

public sealed class BroadbandRecord
{
    public int Oid { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public decimal HomeBroadbandAdoption { get; set; }
    public decimal MobileBroadbandAdoption { get; set; }
    public decimal NoInternetAccessPercentage { get; set; }
    public decimal NoHomeBroadbandAdoption { get; set; }
    public decimal NoMobileBroadbandAdoption { get; set; }
    public BroadbandConnectionLevel NoHomeBroadbandAdoptionLevel { get; set; }
    public BroadbandConnectionLevel NoMobileBroadbandAdoptionLevel { get; set; }
    public int CommercialFiberMaxIsp { get; set; }
    public int PublicComputerCenterCount { get; set; }
    public int WorkstationsInPccs { get; set; }
    public decimal AverageTrainingHoursPerWeek { get; set; }
    public int PublicWiFiCount { get; set; }
    public int PolesReservedByMobile { get; set; }
    public int PolesWithEquipmentInstalled { get; set; }
    public decimal DensityOfPolesReserved { get; set; }
}