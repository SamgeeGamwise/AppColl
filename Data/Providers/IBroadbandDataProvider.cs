using AppColl.Models;

namespace AppColl.Data.Providers;

public interface IBroadbandDataProvider
{
    public Task<BroadbandRecord[]> GetRecordsAsync(CancellationToken cancellationToken = default);
}