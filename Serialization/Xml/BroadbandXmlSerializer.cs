using System.Xml.Serialization;
using AppCollRider.Models;

namespace AppCollRider.Serialization.Xml;

public class BroadbandXmlSerializer : IBroadbandSerializer
{
    public byte[] Serialize(IEnumerable<BroadbandRecord> records)
    {
        var serializer = new XmlSerializer(typeof(BroadbandRecord[]));
        
        using var stream = new MemoryStream();
        serializer.Serialize(stream, records);
        return stream.ToArray();
    }
}