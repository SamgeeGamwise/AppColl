import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit
} from '@angular/core';

import { BroadbandFilters } from './components/broadband-filters/broadband-filters';
import { BroadbandTable } from './components/broadband-table/broadband-table';
import { ExportMenu } from './components/export-menu/export-menu';
import { BroadbandStore } from '../state/broadband.store';

@Component({
  selector: 'app-data-page',
  standalone: true,
  imports: [
    BroadbandFilters,
    BroadbandTable,
    ExportMenu
  ],
  templateUrl: './data.page.html',
  styleUrl: './data.page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DataPage implements OnInit {
  private readonly broadbandStore = inject(BroadbandStore);

  readonly records = this.broadbandStore.records;
  readonly loading = this.broadbandStore.loading;
  readonly error = this.broadbandStore.error;
  readonly query = this.broadbandStore.query;

  ngOnInit(): void {
    // TODO:
    // Load the initial unfiltered records.
  }
}
