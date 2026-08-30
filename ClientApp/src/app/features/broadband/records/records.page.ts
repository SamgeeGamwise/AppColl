import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit
} from '@angular/core';

import { BroadbandStore } from '@broadband/state/broadband.store';
import {RouterLink, RouterLinkActive} from '@angular/router';
import {NgClass} from '@angular/common';
import {BroadbandFilters} from '@broadband/records/components/broadband-filters/broadband-filters';
import {BroadbandTable} from '@broadband/records/components/broadband-table/broadband-table';
import {ExportMenu} from '@broadband/records/components/export-menu/export-menu';
import {BroadbandTabs} from '@broadband/records/components/broadband-tabs/broadband-tabs';
import {BroadbandRecord} from '@broadband/models/broadband-record';

@Component({
  selector: 'app-records-page',
  standalone: true,
  imports: [
    BroadbandFilters,
    BroadbandTable,
    ExportMenu,
    RouterLink,
    NgClass,
    RouterLinkActive,
    BroadbandTabs
  ],
  templateUrl: './records.page.html',
  styleUrl: './records.page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RecordsPage implements OnInit {
  protected readonly broadbandStore = inject(BroadbandStore);

  readonly records = this.broadbandStore.records;
  readonly loading = this.broadbandStore.loading;
  readonly error = this.broadbandStore.error;
  readonly query = this.broadbandStore.query;

  ngOnInit(): void {
    this.broadbandStore.loadRecords();
  }
}
