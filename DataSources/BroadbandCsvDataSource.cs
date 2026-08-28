using System.Globalization;
using AppCollRider.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace AppCollRider.DataSources;

public class BroadbandCsvDataSource(HttpClient httpClient) : IBroadbandDataSource
{
    private const string BroadbandDataUrl = "https://data.cityofnewyork.us/resource/qz5f-yx82.csv";

    public async Task<BroadbandRecord[]> GetRecordsAsync(CancellationToken cancellationToken = default)
    {
        var stream = await httpClient.GetStreamAsync(BroadbandDataUrl, cancellationToken);
        
        using var reader = new StreamReader(stream);
        
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        });

        csv.Context.RegisterClassMap<BroadbandRecordMap>();
        
        return csv.GetRecords<BroadbandRecord>().ToArray();
    }
}