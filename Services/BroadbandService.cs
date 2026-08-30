using AppColl.Data.Providers;
using AppColl.Data.State;
using AppColl.Enums;
using AppColl.Models;
using AppColl.Models.Requests;
using AppColl.Models.Responses;
using AppColl.Serialization.Csv;
using AppColl.Serialization.Json;
using AppColl.Serialization.Xml;

namespace AppColl.Services;

public class BroadbandService(
    IBroadbandStateStore broadbandStateStore, 
    IBroadbandDataProvider broadbandDataProvider, 
    BroadbandCsvSerializer csvSerializer,
    BroadbandJsonSerializer jsonSerializer,
    BroadbandXmlSerializer xmlSerializer
    )
{
    public async Task<Guid> Import()
    {
        var records = await broadbandDataProvider.GetRecordsAsync();
        var guid = Guid.NewGuid();
        
        broadbandStateStore.Add(guid, records);

        return guid;
    }

    public BroadbandExportFile Export(Guid guid, BroadbandExportQuery exportQuery,  BroadbandRecordQuery recordQuery)
    {
        var state = broadbandStateStore.Get(guid);
        var queriedRecords = ApplyQuery(state.Records, recordQuery).ToArray();

        var exportFile = exportQuery.Format switch
        {
            BroadbandExportFormat.Csv => new BroadbandExportFile
            {
                Content = csvSerializer.Serialize(queriedRecords),
                ContentType = "text/csv",
                FileName = $"broadband-{state.ImportedAt}.csv"
            },
            BroadbandExportFormat.Json => new BroadbandExportFile
            {
                Content = jsonSerializer.Serialize(queriedRecords),
                ContentType = "application/json",
                FileName = $"broadband-{state.ImportedAt}.json"
            },
            BroadbandExportFormat.Xml => new BroadbandExportFile
            {
                Content = xmlSerializer.Serialize(queriedRecords),
                ContentType = "application/xml",
                FileName = $"broadband-{state.ImportedAt}.xml"
            },
            _ => throw new ArgumentException(" error")
        };

        return exportFile;
    }

    public BroadbandRecord[] GetRecords(Guid guid, BroadbandRecordQuery recordQuery)
    {
        var state = broadbandStateStore.Get(guid);

        return ApplyQuery(state.Records, recordQuery).ToArray();
    }
    
    public BroadbandSummary GetSummary(Guid guid, BroadbandRecordQuery recordQuery)
    {
        var state = broadbandStateStore.Get(guid);
        var records =  ApplyQuery(state.Records, recordQuery).ToArray();
        
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

    private static IEnumerable<BroadbandRecord> ApplyQuery(IEnumerable<BroadbandRecord> records, BroadbandRecordQuery recordQuery)
    {
        var result = records;

        if (!string.IsNullOrWhiteSpace(recordQuery.ZipCode))
        {
            result = result.Where(record =>
                record.ZipCode == recordQuery.ZipCode.Trim());
        }

        if (recordQuery.MinHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.HomeBroadbandAdoption >=
                recordQuery.MinHomeBroadbandAdoption.Value);
        }

        if (recordQuery.MaxHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.HomeBroadbandAdoption <=
                recordQuery.MaxHomeBroadbandAdoption.Value);
        }

        if (recordQuery.MinMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.MobileBroadbandAdoption >=
                recordQuery.MinMobileBroadbandAdoption.Value);
        }

        if (recordQuery.MaxMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.MobileBroadbandAdoption <=
                recordQuery.MaxMobileBroadbandAdoption.Value);
        }

        if (recordQuery.MinNoInternetAccessPercentage.HasValue)
        {
            result = result.Where(record =>
                record.NoInternetAccessPercentage >=
                recordQuery.MinNoInternetAccessPercentage.Value);
        }

        if (recordQuery.MaxNoInternetAccessPercentage.HasValue)
        {
            result = result.Where(record =>
                record.NoInternetAccessPercentage <=
                recordQuery.MaxNoInternetAccessPercentage.Value);
        }

        if (recordQuery.MinNoHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoHomeBroadbandAdoption >=
                recordQuery.MinNoHomeBroadbandAdoption.Value);
        }

        if (recordQuery.MaxNoHomeBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoHomeBroadbandAdoption <=
                recordQuery.MaxNoHomeBroadbandAdoption.Value);
        }

        if (recordQuery.MinNoMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoMobileBroadbandAdoption >=
                recordQuery.MinNoMobileBroadbandAdoption.Value);
        }

        if (recordQuery.MaxNoMobileBroadbandAdoption.HasValue)
        {
            result = result.Where(record =>
                record.NoMobileBroadbandAdoption <=
                recordQuery.MaxNoMobileBroadbandAdoption.Value);
        }

        return result;
    }
}