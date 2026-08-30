using System.Text.Json;
using System.Text.Json.Serialization;
using AppColl.Models;

namespace AppColl.Serialization.Json;

public class BroadbandJsonSerializer : IBroadbandSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
    
    public byte[] Serialize(IEnumerable<BroadbandRecord> records)
    {
        return JsonSerializer.SerializeToUtf8Bytes(records, Options);
    }
}