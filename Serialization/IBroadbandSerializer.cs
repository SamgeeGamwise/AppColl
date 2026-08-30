using AppColl.Models;

namespace AppColl.Serialization;

public interface IBroadbandSerializer
{
    public byte[] Serialize(IEnumerable<BroadbandRecord> records);
}