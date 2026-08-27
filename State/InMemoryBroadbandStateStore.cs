using AppCollRider.Models;

namespace AppCollRider.State;

public class InMemoryBroadbandStateStore : IBroadbandStateStore
{
    private readonly List<BroadbandImportState> _workspaces = [];

    public bool Has(Guid stateId)
    {
        return  _workspaces.Any(w => w.Id == stateId);
    }

    public void Add(Guid guid, BroadbandRecord[] records)
    {
        _workspaces.Add(new BroadbandImportState
        {
            Id = guid,
            Records = records,
            ImportedAt = DateTime.Now
        });
    }

    public BroadbandImportState Get(Guid stateId)
    {
        var workspace = _workspaces.FirstOrDefault(w => w.Id == stateId);

        return workspace ?? throw new ArgumentException("Broadband state not found", nameof(stateId));
    }

    public void Remove(Guid stateId)
    {
        _workspaces.RemoveAll(w => w.Id == stateId);
    }
}