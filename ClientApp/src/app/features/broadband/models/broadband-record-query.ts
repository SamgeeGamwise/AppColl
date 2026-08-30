export interface BroadbandRecordQuery {
  zipCode?: string;

  maxHomeBroadbandAdoption?: number;
  minHomeBroadbandAdoption?: number;

  maxMobileBroadbandAdoption?: number;
  minMobileBroadbandAdoption?: number;

  maxNoInternetAccessPercentage?: number;
  minNoInternetAccessPercentage?: number;

  maxNoHomeBroadbandAdoption?: number;
  minNoHomeBroadbandAdoption?: number;

  maxNoMobileBroadbandAdoption?: number;
  minNoMobileBroadbandAdoption?: number;
}
