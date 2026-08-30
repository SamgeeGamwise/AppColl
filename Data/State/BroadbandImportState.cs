using AppColl.Models;

namespace AppColl.Data.State;

public class BroadbandImportState
{
    public Guid Id { get; init; }
    public IReadOnlyCollection<BroadbandRecord> Records { get; init; } = [];
    public DateTime ImportedAt { get; set; }
}