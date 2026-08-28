using AppCollRider.DataSources;
using AppCollRider.Models;
using AppCollRider.State;

namespace AppCollRider.Services;

public class BroadbandService(IBroadbandStateStore broadbandStateStore, IBroadbandDataSource broadbandDataSource)
{
    public async Task<Guid> Import()
    {
        var records = await broadbandDataSource.GetRecordsAsync();
        var guid = Guid.NewGuid();
        
        broadbandStateStore.Add(guid, records);

        return guid;
    }

    public BroadbandRecord[] GetRecords(Guid guid, BroadbandQuery query)
    {
        var state = broadbandStateStore.Get(guid);

        return ApplyQuery(state.Records, query).ToArray();
    }
    
    public BroadbandSummary GetSummary(Guid guid, BroadbandQuery query)
    {
        var state = broadbandStateStore.Get(guid);
        var records =  ApplyQuery(state.Records, query).ToArray();
        
        return Summarize(records);
    }
    
    public void Reset(Guid guid)
    {
        broadbandStateStore.Remove(guid);
    }
    
    public BroadbandStatus GetStateStatus(Guid? guid)
    {
        if (guid is null || !broadbandStateStore.Has(guid.Value))
        {
            return new BroadbandStatus
            {
                HasImportedData = false
            };
        }
        
        var state = broadbandStateStore.Get(guid.Value);
        
        return new BroadbandStatus
        {
            HasImportedData = true,
            RecordCount = state.Records.Count,
            ImportedAt = state.ImportedAt,
        };
    }

    private static BroadbandSummary Summarize(IReadOnlyCollection<BroadbandRecord> records)
    {
        if (records.Count == 0)
        {
            return new BroadbandSummary();
        }

        return new BroadbandSummary
        {
            RecordCount = records.Count,

            UniqueZipCodeCount = records
                .Select(record => record.ZipCode)
                .Distinct()
                .Count(),

            AverageHomeBroadbandAdoption = Round4(records
                .Average(record => record.HomeBroadbandAdoption)),

            AverageMobileBroadbandAdoption = Round4(records
                .Average(record => record.MobileBroadbandAdoption)),

            AverageNoInternetAccessPercentage = Round4(records
                .Average(record => record.NoInternetAccessPercentage)),

            AverageNoHomeBroadbandAdoption = Round4(records
                .Average(record => record.NoHomeBroadbandAdoption)),

            AverageNoMobileBroadbandAdoption = Round4(records
                .Average(record => record.NoMobileBroadbandAdoption)),

            AverageCommercialFiberMaxIsp = Round4(records
                .Average(record => (decimal)record.CommercialFiberMaxIsp)),

            AveragePublicComputerCenterCount = Round4(records
                .Average(record => (decimal)record.PublicComputerCenterCount)),

            AverageWorkstationsInPccs = Round4(records
                .Average(record => (decimal)record.WorkstationsInPccs)),

            AverageTrainingHoursPerWeek = Round4(records
                .Average(record => record.AverageTrainingHoursPerWeek)),

            AveragePublicWiFiCount = Round4(records
                .Average(record => (decimal)record.PublicWiFiCount)),

            AveragePolesReservedByMobile = Round4(records
                .Average(record => (decimal)record.PolesReservedByMobile)),

            AveragePolesWithEquipmentInstalled = Round4(records
                .Average(record => (decimal)record.PolesWithEquipmentInstalled)),

            AverageDensityOfPolesReserved = Round4(records
                .Average(record => record.DensityOfPolesReserved))
        };

        static decimal Round4(decimal value) =>
            Math.Round(value, 4);
    }

    private static IEnumerable<BroadbandRecord> ApplyQuery(IEnumerable<BroadbandRecord> records, BroadbandQuery query)
    {
        var result = records;

        if (!string.IsNullOrWhiteSpace(query.ZipCode))
        {
            result = result.Where(record =>
                record.ZipCode == query.ZipCode.Trim());
        }

        if (query.MinHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.HomeBroadbandAdoption >=
                query.MinHomeBroadbandAdoption.Value);
        }

        if (query.MaxHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.HomeBroadbandAdoption <=
                query.MaxHomeBroadbandAdoption.Value);
        }

        if (query.MinMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.MobileBroadbandAdoption >=
                query.MinMobileBroadbandAdoption.Value);
        }

        if (query.MaxMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.MobileBroadbandAdoption <=
                query.MaxMobileBroadbandAdoption.Value);
        }

        if (query.MinNoInternetAccessPercentage.HasValue)
        {
            result = result.Where(record =>
                record.NoInternetAccessPercentage >=
                query.MinNoInternetAccessPercentage.Value);
        }

        if (query.MaxNoInternetAccessPercentage.HasValue)
        {
            result = result.Where(record =>
                record.NoInternetAccessPercentage <=
                query.MaxNoInternetAccessPercentage.Value);
        }

        if (query.MinNoHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoHomeBroadbandAdoption >=
                query.MinNoHomeBroadbandAdoption.Value);
        }

        if (query.MaxNoHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoHomeBroadbandAdoption <=
                query.MaxNoHomeBroadbandAdoption.Value);
        }

        if (query.MinNoMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoMobileBroadbandAdoption >=
                query.MinNoMobileBroadbandAdoption.Value);
        }

        if (query.MaxNoMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoMobileBroadbandAdoption <=
                query.MaxNoMobileBroadbandAdoption.Value);
        }

        return result;
    }
}