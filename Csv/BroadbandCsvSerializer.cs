using System.Globalization;
using System.Text;
using AppCollRider.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace AppCollRider.Csv;

public class BroadbandCsvSerializer
{
    public File Serieralize(BroadbandRecord[] records)
    {
        var stream = new MemoryStream();
        
        using (var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<BroadbandCsvRecordMap>();
            csv.WriteRecords(records);
        }
            
        var bytes = stream.ToArray();
        
        return File(
            bytes,
            "text/csv",
            "broadband.csv");
    }
    
    public static BroadbandRecord[] Deserialize(StreamReader reader)
    {
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        });

        csv.Context.RegisterClassMap<BroadbandCsvRecordMap>();
        
        return csv.GetRecords<BroadbandRecord>().ToArray();
    }
}