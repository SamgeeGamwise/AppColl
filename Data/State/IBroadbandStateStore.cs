using AppColl.Models;

namespace AppColl.Data.State;

public interface IBroadbandStateStore
{
    public bool Has(Guid stateId);
    public void Add(Guid guid, IReadOnlyCollection<BroadbandRecord> records);
    public BroadbandImportState Get(Guid stateId);
    public void Remove(Guid stateId);
}