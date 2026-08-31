import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';

import { BroadbandStore } from '@broadband/state/broadband.store';
import { BroadbandTabs } from '@broadband/records/components/broadband-tabs/broadband-tabs';
import { DecimalPipe } from '@angular/common';

import { BroadbandFilters } from '@broadband/records/components/broadband-filters/broadband-filters';

@Component({
  selector: 'app-summary-page',
  standalone: true,
  templateUrl: './summary.page.html',
  styleUrl: './summary.page.scss',
  imports: [BroadbandTabs, DecimalPipe, BroadbandFilters],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SummaryPage implements OnInit {
  private readonly broadbandStore = inject(BroadbandStore);
  readonly summary = this.broadbandStore.summary;
  readonly loading = this.broadbandStore.loading;
  readonly error = this.broadbandStore.error;

  ngOnInit(): void {
    this.broadbandStore.loadSummary();
  }
}
