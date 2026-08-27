using AppCollRider.DataSources;
using AppCollRider.Models;
using AppCollRider.State;

namespace AppCollRider.Services;

public class BroadbandService
{
    
    private readonly IBroadbandStateStore _broadbandStateStore;
    private readonly IBroadbandDataSource _broadbandDataSource;

    public BroadbandService(IBroadbandStateStore broadbandStateStore, IBroadbandDataSource broadbandDataSource)
    {
        _broadbandStateStore = broadbandStateStore;
        _broadbandDataSource = broadbandDataSource;
    }

    public async Task<Guid> Import()
    {
        var records = await _broadbandDataSource.GetRecordsAsync();
        var guid = Guid.NewGuid();
        
        _broadbandStateStore.Add(guid, records);

        return guid;
    }

    public BroadbandRecord[] GetRecords(Guid guid)
    {
        return _broadbandStateStore.Get(guid).Records;
    }
    
    public BroadbandRecord[] GetSummary(Guid guid)
    {
        return _broadbandStateStore.Get(guid).Records;
    }
    
    
}