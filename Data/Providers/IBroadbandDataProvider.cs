using AppCollRider.Models;

namespace AppCollRider.Providers;

public interface IBroadbandDataProvider
{
    public Task<BroadbandRecord[]> GetRecordsAsync(CancellationToken cancellationToken = default);
}