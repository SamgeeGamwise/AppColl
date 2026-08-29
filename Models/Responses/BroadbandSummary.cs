namespace AppCollRider.Models.Response;

public class BroadbandSummary
{
    public int RecordCount { get; init; }
    public int UniqueZipCodeCount { get; init; }
    public decimal AverageHomeBroadbandAdoption { get; init; }
    public decimal AverageMobileBroadbandAdoption { get; init; }
    public decimal AverageNoInternetAccessPercentage { get; init; }
    public decimal AverageNoHomeBroadbandAdoption { get; init; }
    public decimal AverageNoMobileBroadbandAdoption { get; init; }
    public decimal AverageCommercialFiberMaxIsp { get; init; }
    public decimal AveragePublicComputerCenterCount { get; init; }
    public decimal AverageWorkstationsInPccs { get; init; }
    public decimal AverageTrainingHoursPerWeek { get; init; }
    public decimal AveragePublicWiFiCount { get; init; }
    public decimal AveragePolesReservedByMobile { get; init; }
    public decimal AveragePolesWithEquipmentInstalled { get; init; }
    public decimal AverageDensityOfPolesReserved { get; init; }
}