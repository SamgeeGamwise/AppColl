import {
  ChangeDetectionStrategy,
  Component,
  inject
} from '@angular/core';
import {
  Router,
  RouterLink,
  RouterLinkActive
} from '@angular/router';

import { BroadbandStore } from '../../../features/broadband/state/broadband.store';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Navbar {
  private readonly router = inject(Router);
  private readonly broadbandStore = inject(BroadbandStore);

  startOver(): void {
    // TODO:
    // 1. Call backend reset
    // 2. Clear BroadbandStore
    // 3. Navigate to /import

    // Eventually:
    //
    // this.broadbandStore.reset();
    // this.router.navigate(['/import']);
  }
}
