export interface BroadbandRecordQuery {
  zipCode: string | null;

  maxHomeBroadbandAdoption: number | null;
  minHomeBroadbandAdoption: number | null;

  maxMobileBroadbandAdoption: number | null;
  minMobileBroadbandAdoption: number | null;

  maxNoInternetAccessPercentage: number | null;
  minNoInternetAccessPercentage: number | null;

  maxNoHomeBroadbandAdoption: number | null;
  minNoHomeBroadbandAdoption: number | null;

  maxNoMobileBroadbandAdoption: number | null;
  minNoMobileBroadbandAdoption: number | null;
}
