using AppCollRider.Models;

namespace AppCollRider.Serialization;

public interface IBroadbandSerializer
{
    public byte[] Serialize(IEnumerable<BroadbandRecord> records);
}