export interface BroadbandSummary {
  recordCount: number;
  uniqueZipCodeCount: number;

  averageHomeBroadbandAdoption: number;
  averageMobileBroadbandAdoption: number;

  averageNoInternetAccessPercentage: number;
  averageNoHomeBroadbandAdoption: number;
  averageNoMobileBroadbandAdoption: number;

  averageCommercialFiberMaxIsp: number;
  averagePublicComputerCenterCount: number;
  averageWorkstationsInPccs: number;
  averageTrainingHoursPerWeek: number;
  averagePublicWiFiCount: number;

  averagePolesReservedByMobile: number;
  averagePolesWithEquipmentInstalled: number;
  averageDensityOfPolesReserved: number;
}
