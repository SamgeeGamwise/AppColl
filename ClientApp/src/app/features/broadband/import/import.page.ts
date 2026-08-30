import {
  ChangeDetectionStrategy,
  Component,
  inject
} from '@angular/core';
import { Router } from '@angular/router';

import { BroadbandStore } from '@broadband/state/broadband.store';
import {NavbarComponent} from '@app/shared/components/navbar/navbar.component';

@Component({
  selector: 'app-import-page',
  standalone: true,
  templateUrl: './import.page.html',
  styleUrl: './import.page.scss',
  imports: [
    NavbarComponent
  ],
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
  this.broadbandStore.importData().subscribe({
    next: broadbandStatus => {
      if (broadbandStatus.hasImportedData) {
        this.router.navigateByUrl('/records').then(r => {});
      }
    }
  });
  }
}
