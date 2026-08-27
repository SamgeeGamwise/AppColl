namespace AppCollRider.Models;

public class BroadbandSummary
{
    public int RecordCount { get; set; }
    public int UniqueZipCodesCount { get; set; }
    public decimal AverageHomeBroadbandAdoption { get; set; }
    public decimal AverageMobileBroadbandAdoption { get; set; }
    public decimal AverageNoInternetAccessPercentage { get; set; }
    public decimal AverageNoHomeBroadbandAdoption { get; set; }
    public decimal AverageNoMobileBroadbandAdoption { get; set; }
    public int AverageCommercialFiberMaxIsp { get; set; }
    public int AveragePublicComputerCenterCount { get; set; }
    public int AverageWorkstationsInPccs { get; set; }
    public decimal AverageOfAverageTrainingHoursPerWeek { get; set; }
    public int AveragePublicWiFiCount { get; set; }
    public int AveragePolesReservedByMobile { get; set; }
    public int AveragePolesWithEquipmentInstalled { get; set; }
    public decimal AverageDensityOfPolesReserved { get; set; }
}