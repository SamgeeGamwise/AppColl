using AppCollRider.Models;

namespace AppCollRider.DataSources;

public interface IBroadbandDataSource
{
    public Task<BroadbandRecord[]> GetRecordsAsync(CancellationToken cancellationToken = default);
}