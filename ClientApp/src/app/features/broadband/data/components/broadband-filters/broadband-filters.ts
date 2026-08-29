import {
  ChangeDetectionStrategy,
  Component,
  input,
  output
} from '@angular/core';

import { BroadbandRecordQuery } from '../../../models/broadband-record-query';

@Component({
  selector: 'app-broadband-filters',
  standalone: true,
  template: `
    <!-- Filter UI will go here -->
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BroadbandFilters {
  readonly query = input<BroadbandRecordQuery>({});

  readonly queryChange = output<BroadbandRecordQuery>();
}
