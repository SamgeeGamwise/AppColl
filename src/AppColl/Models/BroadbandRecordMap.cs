using AppColl.Enums;
using CsvHelper.Configuration;

namespace AppColl.Models
{
    public class BroadbandRecordMap : ClassMap<BroadbandRecord>
    {
        public BroadbandRecordMap()
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
                .Convert(args => StringToConnectionLevel(args.Row.GetField("no_home_broadband_adoption_1")));

            Map(x => x.NoMobileBroadbandAdoptionLevel)
                .Name("no_mobile_broadband_adoption_1")
                .Convert(args => StringToConnectionLevel(args.Row.GetField("no_mobile_broadband_adoption_1")));

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

        private static ConnectionLevel StringToConnectionLevel(string? connectionLevel)
        {
            return connectionLevel switch
            {
                "Low Connected" => ConnectionLevel.LowConnected,
                "Medium Low Connected" => ConnectionLevel.MediumLowConnected,
                "Medium Connected" => ConnectionLevel.MediumConnected,
                "Medium High Connected" => ConnectionLevel.MediumHighConnected,
                "High Connected" => ConnectionLevel.HighConnected,
                _ => throw new ArgumentException(
                    $"Unknown connection level: {connectionLevel}")
            };
        }

        private static string ConnectionLevelToString(ConnectionLevel connectionLevel)
        {
            return connectionLevel switch
            {
                ConnectionLevel.LowConnected => "Low Connected",
                ConnectionLevel.MediumLowConnected => "Medium Low Connected",
                ConnectionLevel.MediumConnected => "Medium Connected",
                ConnectionLevel.MediumHighConnected => "Medium High Connected",
                ConnectionLevel.HighConnected => "High Connected",
                _ => throw new ArgumentException(
                    $"Unknown connection level: {connectionLevel}")
            };
        }
    }
}
