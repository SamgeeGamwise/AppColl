using AppColl.Enums;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace AppColl.Serialization.Csv;

public class BroadbandConnectionLevelConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        return text switch
        {
            "Low Connected" => BroadbandConnectionLevel.LowConnected,
            "Medium Low Connected" => BroadbandConnectionLevel.MediumLowConnected,
            "Medium Connected" => BroadbandConnectionLevel.MediumConnected,
            "Medium High Connected" => BroadbandConnectionLevel.MediumHighConnected,
            "High Connected" => BroadbandConnectionLevel.HighConnected,
            _ => throw new ArgumentException($"Unknown connection level: {text}")
        };
    }

    public override string ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
    {
        return value switch
        {
            BroadbandConnectionLevel.LowConnected => "Low Connected",
            BroadbandConnectionLevel.MediumLowConnected => "Medium Low Connected",
            BroadbandConnectionLevel.MediumConnected => "Medium Connected",
            BroadbandConnectionLevel.MediumHighConnected => "Medium High Connected",
            BroadbandConnectionLevel.HighConnected => "High Connected",
            _ => throw new ArgumentException($"Unknown connection level: {value}")
        };
    }
}