using System.Globalization;
using System.Text;
using AppColl.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace AppColl.Serialization.Csv;

public class BroadbandCsvSerializer : IBroadbandSerializer, IBroadbandDeserializer
{
    public byte[] Serialize(IEnumerable<BroadbandRecord> records)
    {
        var stream = new MemoryStream();
        
        using (var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<BroadbandCsvRecordMap>();
            csv.WriteRecords(records);
        }
            
        var bytes = stream.ToArray();


        return bytes;
    }
    
    public BroadbandRecord[] Deserialize(StreamReader reader)
    {
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        });

        csv.Context.RegisterClassMap<BroadbandCsvRecordMap>();
        
        return csv.GetRecords<BroadbandRecord>().ToArray();
    }
}