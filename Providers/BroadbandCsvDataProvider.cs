using AppCollRider.Csv;
using AppCollRider.Models;

namespace AppCollRider.Providers;

public class BroadbandCsvDataProvider(HttpClient httpClient, BroadbandCsvSerializer csvSerializer) : IBroadbandDataSource
{
    private const string BroadbandDataUrl = "https://data.cityofnewyork.us/resource/qz5f-yx82.csv";

    public async Task<BroadbandRecord[]> GetRecordsAsync(CancellationToken cancellationToken = default)
    {
        var stream = await httpClient.GetStreamAsync(BroadbandDataUrl, cancellationToken);
        
        using var reader = new StreamReader(stream);
        
        return BroadbandCsvSerializer.Deserialize(reader);
    }
}