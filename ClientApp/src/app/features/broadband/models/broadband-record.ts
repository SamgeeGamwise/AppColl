// broadband.models.ts

export interface BroadbandRecord {
  oid: number;
  zip_code: string;

  home_broadband_adoption: number;
  mobile_broadband_adoption: number;

  no_internet_access_percentage: number;
  no_home_broadband_adoption: number;
  no_mobile_broadband_adoption: number;

  no_home_broadband_adoption_1: string;
  no_mobile_broadband_adoption_1: string;

  commercial_fiber_max_isp: number;

  public_computer_center_count: number;
  workstations_in_pccs: number;
  avg_training_hrs_per_week: number;

  public_wi_fi_count: number;

  poles_reserved_by_mobile: number;
  pole_with_equipment_installed: number;
  density_of_poles_reserved: number;
}
