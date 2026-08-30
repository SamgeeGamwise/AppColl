import {
  ChangeDetectionStrategy,
  Component, CUSTOM_ELEMENTS_SCHEMA,
  inject
} from '@angular/core';
import {
  Router,
} from '@angular/router';

import { BroadbandStore } from '@broadband/state/broadband.store';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class NavbarComponent {
  private readonly router = inject(Router);
  protected readonly broadbandStore = inject(BroadbandStore);
  protected readonly status = this.broadbandStore.status;

  public reset(): void {
    this.broadbandStore.clear().subscribe({
      next: broadbandStatus => {
        if (!broadbandStatus.hasImportedData) {
          this.router.navigateByUrl('/import').then(r => {});
        }
      }
    });
  }
}
