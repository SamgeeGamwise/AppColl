
using AppColl.Models;
using AppColl.Workspaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AppColl.Services
{
    public class ImportService(HttpClient httpClient, BroadbandWorkspaceStore workspaceStore)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly BroadbandWorkspaceStore _workspaceStore = workspaceStore;
        private const string BroadbandDataUrl = "https://data.cityofnewyork.us/resource/qz5f-yx82.csv";

        public async Task<(int workspaceId, BroadbandRecord[] records)> ImportBroadband()
        {
            var stream = await _httpClient.GetStreamAsync(BroadbandDataUrl);
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            });

            csv.Context.RegisterClassMap<BroadbandRecordMap>();

            var records = csv.GetRecords<BroadbandRecord>().ToArray();

            var workspaceId = _workspaceStore.AddWorkspace(records);

            return (workspaceId, records);
        }
    }
}
