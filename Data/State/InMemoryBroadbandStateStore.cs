using AppColl.Models;

namespace AppColl.Data.State;

public class InMemoryBroadbandStateStore : IBroadbandStateStore
{
    private readonly List<BroadbandImportState> _states = [];

    public bool Has(Guid stateId)
    {
        return  _states.Any(w => w.Id == stateId);
    }

    public void Add(Guid guid, IReadOnlyCollection<BroadbandRecord> records)
    {
        _states.Add(new BroadbandImportState
        {
            Id = guid,
            Records = records,
            ImportedAt = DateTime.Now
        });
    }

    public BroadbandImportState Get(Guid stateId)
    {
        var states = _states.First(w => w.Id == stateId);

        return states;
    }

    public void Remove(Guid stateId)
    {
        _states.RemoveAll(w => w.Id == stateId);
    }
}