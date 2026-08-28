using AppCollRider.Models;

namespace AppCollRider.Csv;

public interface IBroadbandDataSource
{
    public Task<BroadbandRecord[]> GetRecordsAsync(CancellationToken cancellationToken = default);
}