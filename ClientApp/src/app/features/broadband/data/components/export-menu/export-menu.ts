import {
  ChangeDetectionStrategy,
  Component,
  output
} from '@angular/core';

import { BroadbandExportFormat } from '../../../models/broadband-export-format';

@Component({
  selector: 'app-export-menu',
  standalone: true,
  template: `
    <!-- Export dropdown/menu will go here -->
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExportMenu {
  readonly exportRequested = output<BroadbandExportFormat>();
}
