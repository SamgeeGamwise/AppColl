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
}
