namespace AppColl.Models.Requests;

public sealed class BroadbandRecordQuery
{
    public string? ZipCode { get; init; }
    public decimal? MaxHomeBroadbandAdoption { get; init; }
    public decimal? MinHomeBroadbandAdoption { get; init; }
    public decimal? MaxMobileBroadbandAdoption { get; init; }
    public decimal? MinMobileBroadbandAdoption { get; init; }
    public decimal? MaxNoInternetAccessPercentage { get; init; }
    public decimal? MinNoInternetAccessPercentage { get; init; }
    public decimal? MaxNoHomeBroadbandAdoption { get; init; }
    public decimal? MinNoHomeBroadbandAdoption { get; init; }
    public decimal? MaxNoMobileBroadbandAdoption { get; init; }
    public decimal? MinNoMobileBroadbandAdoption { get; init; }
}