using AppCollRider.Models;

namespace AppCollRider.State;

public class BroadbandImportState
{
    public Guid Id { get; set; }
    public BroadbandRecord[] Records { get; set; } = [];
    public DateTime ImportedAt { get; set; }
}