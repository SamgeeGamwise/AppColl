import {
  ChangeDetectionStrategy,
  Component,
  inject
} from '@angular/core';
import { Router } from '@angular/router';

import { BroadbandStore } from '../state/broadband.store';

@Component({
  selector: 'app-import-page',
  standalone: true,
  templateUrl: './import.page.html',
  styleUrl: './import.page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImportPage {
  private readonly router = inject(Router);
  private readonly broadbandStore = inject(BroadbandStore);

  // Eventually expose store state:
  //
  // readonly loading = this.broadbandStore.loading;
  // readonly error = this.broadbandStore.error;

  importData(): void {
    // TODO:
    // 1. Call broadbandStore.importData()
    // 2. Wait for success
    // 3. Navigate to /data

    // Example later:
    // this.router.navigate(['/data']);
  }
}
