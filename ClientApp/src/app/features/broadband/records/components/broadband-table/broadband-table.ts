import {
  ChangeDetectionStrategy,
  Component,
  input
} from '@angular/core';

import { BroadbandRecord } from '@app/features/broadband/models/broadband-record';

@Component({
  selector: 'app-broadband-table',
  standalone: true,
  templateUrl: './broadband-table.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BroadbandTable {
  readonly records = input<BroadbandRecord[]>([]);

  readonly columnHeaders: string[] = [
    "Zip Code",
    "Home Broadband Adoption",
    "Mobile Broadband Adoption",
    "No Internet Access Percentage",
    "No Home Broadband Adoption",
    "No Mobile Broadband Adoption",
    "No Home Broadband Adoption Level",
    "No Mobile Broadband Adoption Level",
    "Commercial Fiber Max ISP",
    "Public Computer Center Count",
    "Workstations in PCCs",
    "Average Training Hours per Week",
    "Public Wi-Fi Count",
    "Poles Reserved by Mobile",
    "Poles With Equipment Installed",
    "Density of Poles Reserved"
  ];
}
