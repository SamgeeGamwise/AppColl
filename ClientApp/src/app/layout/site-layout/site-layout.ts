import {
  ChangeDetectionStrategy,
  Component, inject
} from '@angular/core';
import { RouterOutlet } from '@angular/router';

import {NavbarComponent} from '@app/shared/components/navbar/navbar.component';
import {SpinnerComponent} from '@app/shared/components/spinner/spinner.component';
import {BroadbandStore} from '@broadband/state/broadband.store';
import {AlertComponent} from '@app/shared/components/alert/alert.component';

@Component({
  selector: 'app-site-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    SpinnerComponent,
    NavbarComponent,
    AlertComponent
  ],
  templateUrl: './site-layout.html',
  styleUrl: './site-layout.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SiteLayout {
  protected readonly broadbandStore = inject(BroadbandStore);
}
