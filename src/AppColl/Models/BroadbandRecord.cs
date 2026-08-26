using AppColl.Enums;

namespace AppColl.Models
{
    public class BroadbandRecord
    {
        public int Oid { get; set; }
        public required string ZipCode { get; set; }
        public decimal HomeBroadbandAdoption { get; set; }
        public decimal MobileBroadbandAdoption { get; set; }
        public decimal NoInternetAccessPercentage { get; set; }
        public decimal NoHomeBroadbandAdoption { get; set; }
        public decimal NoMobileBroadbandAdoption { get; set; }
        public ConnectionLevel NoHomeBroadbandAdoptionLevel { get; set; }
        public ConnectionLevel NoMobileBroadbandAdoptionLevel { get; set; }
        public int CommercialFiberMaxIsp { get; set; }
        public int PublicComputerCenterCount { get; set; }
        public int WorkstationsInPccs { get; set; }
        public decimal AverageTrainingHoursPerWeek { get; set; }
        public int PublicWiFiCount { get; set; }
        public int PolesReservedByMobile { get; set; }
        public int PolesWithEquipmentInstalled { get; set; }
        public decimal DensityOfPolesReserved { get; set; }

        public override string ToString()
        {
            return
                $"OID: {Oid}\n" +
                $"Zip Code: {ZipCode}\n" +
                $"Home Broadband Adoption: {HomeBroadbandAdoption}\n" +
                $"Mobile Broadband Adoption: {MobileBroadbandAdoption}\n" +
                $"No Internet Access %: {NoInternetAccessPercentage}\n" +
                $"No Home Broadband Adoption: {NoHomeBroadbandAdoption}\n" +
                $"No Mobile Broadband Adoption: {NoMobileBroadbandAdoption}\n" +
                $"Home Connection Level: {NoHomeBroadbandAdoptionLevel}\n" +
                $"Mobile Connection Level: {NoMobileBroadbandAdoptionLevel}\n" +
                $"Commercial Fiber Max ISP: {CommercialFiberMaxIsp}\n" +
                $"Public Computer Centers: {PublicComputerCenterCount}\n" +
                $"Workstations in PCCs: {WorkstationsInPccs}\n" +
                $"Avg Training Hours/Week: {AverageTrainingHoursPerWeek}\n" +
                $"Public WiFi Count: {PublicWiFiCount}\n" +
                $"Poles Reserved by Mobile: {PolesReservedByMobile}\n" +
                $"Poles With Equipment Installed: {PolesWithEquipmentInstalled}\n" +
                $"Density of Poles Reserved: {DensityOfPolesReserved}";
        }
    }
}
