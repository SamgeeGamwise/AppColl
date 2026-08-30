using AppColl.Models;

namespace AppColl.Serialization;

public interface IBroadbandDeserializer
{
    public BroadbandRecord[] Deserialize(StreamReader reader);
}