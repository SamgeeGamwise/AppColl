import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit
} from '@angular/core';

import { BroadbandStore } from '../state/broadband.store';

@Component({
  selector: 'app-summary-page',
  standalone: true,
  templateUrl: './summary.page.html',
  styleUrl: './summary.page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SummaryPage implements OnInit {
  private readonly broadbandStore = inject(BroadbandStore);

  readonly loading = this.broadbandStore.loading;
  readonly error = this.broadbandStore.error;

  ngOnInit(): void {
    // TODO:
    // Load summary information.
  }
}
