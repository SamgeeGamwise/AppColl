namespace AppCollRider.Models.Response;

public class BroadbandStatus
{
    public bool HasImportedData { get; init; }
    public int? RecordCount { get; init; }
    public DateTime? ImportedAt { get; init; }
}