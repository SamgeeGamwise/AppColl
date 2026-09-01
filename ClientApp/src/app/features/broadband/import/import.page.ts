import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Router } from '@angular/router';

import { BroadbandStore } from '@broadband/state/broadband.store';

@Component({
  selector: 'app-import-page',
  standalone: true,
  templateUrl: './import.page.html',
  styleUrl: './import.page.scss',
  imports: [],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ImportPage {
  private readonly router = inject(Router);
  private readonly broadbandStore = inject(BroadbandStore);

  importData(): void {
    this.broadbandStore.importData().subscribe({
      next: (broadbandStatus) => {
        if (broadbandStatus.hasImportedData) {
          this.router.navigateByUrl('/records').then((r) => {});
        }
      },
    });
  }
}
