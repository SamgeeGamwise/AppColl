using AppCollRider.Models;

namespace AppCollRider.Serialization;

public interface IBroadbandDeserializer
{
    public BroadbandRecord[] Deserialize(StreamReader reader);
}