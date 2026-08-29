import {
  ChangeDetectionStrategy,
  Component,
  input
} from '@angular/core';

import { BroadbandRecord } from '../../../models/broadband-record';

@Component({
  selector: 'app-broadband-table',
  standalone: true,
  template: `
    <!-- Broadband table will go here -->
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BroadbandTable {
  readonly records = input<BroadbandRecord[]>([]);
}
