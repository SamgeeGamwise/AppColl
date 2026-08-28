using AppCollRider.Enums;
using AppCollRider.Models;
using CsvHelper.Configuration;

namespace AppCollRider.Csv;

internal sealed class BroadbandCsvRecordMap : ClassMap<BroadbandRecord>
{
    private BroadbandCsvRecordMap()
    {
        Map(x => x.Oid)
            .Name("oid");

        Map(x => x.ZipCode)
            .Name("zip_code");

        Map(x => x.HomeBroadbandAdoption)
            .Name("home_broadband_adoption");

        Map(x => x.MobileBroadbandAdoption)
            .Name("mobile_broadband_adoption");

        Map(x => x.NoInternetAccessPercentage)
            .Name("no_internet_access_percentage");

        Map(x => x.NoHomeBroadbandAdoption)
            .Name("no_home_broadband_adoption");

        Map(x => x.NoMobileBroadbandAdoption)
            .Name("no_mobile_broadband_adoption");

        Map(x => x.NoHomeBroadbandAdoptionLevel)
            .Name("no_home_broadband_adoption_1")
            .TypeConverter<BroadbandConnectionLevelConverter>();

        Map(x => x.NoMobileBroadbandAdoptionLevel)
            .Name("no_mobile_broadband_adoption_1")
            .TypeConverter<BroadbandConnectionLevelConverter>();

        Map(x => x.CommercialFiberMaxIsp)
            .Name("commercial_fiber_max_isp");

        Map(x => x.PublicComputerCenterCount)
            .Name("public_computer_center_count");

        Map(x => x.WorkstationsInPccs)
            .Name("workstations_in_pccs");

        Map(x => x.AverageTrainingHoursPerWeek)
            .Name("avg_training_hrs_per_week");

        Map(x => x.PublicWiFiCount)
            .Name("public_wi_fi_count");

        Map(x => x.PolesReservedByMobile)
            .Name("poles_reserved_by_mobile");

        Map(x => x.PolesWithEquipmentInstalled)
            .Name("pole_with_equipment_installed");

        Map(x => x.DensityOfPolesReserved)
            .Name("density_of_poles_reserved");
    }

    private static BroadbandConnectionLevel StringToConnectionLevel(string? connectionLevel)
    {
        return connectionLevel switch
        {
            "Low Connected" => BroadbandConnectionLevel.LowConnected,
            "Medium Low Connected" => BroadbandConnectionLevel.MediumLowConnected,
            "Medium Connected" => BroadbandConnectionLevel.MediumConnected,
            "Medium High Connected" => BroadbandConnectionLevel.MediumHighConnected,
            "High Connected" => BroadbandConnectionLevel.HighConnected,
            _ => throw new ArgumentException(
                $"Unknown connection level: {connectionLevel}")
        };
    }
}