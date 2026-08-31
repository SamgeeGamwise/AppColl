import {
  ChangeDetectionStrategy,
  Component, CUSTOM_ELEMENTS_SCHEMA, inject,
  input,
  output
} from '@angular/core';

import {BroadbandRecordQuery} from '@broadband/models/broadband-record-query';
import {
  FiltersInputComponent
} from '@broadband/records/components/broadband-filters/components/filters-input/filters-input-component';
import {BroadbandStore} from '@broadband/state/broadband.store';

@Component({
  selector: 'app-broadband-filters',
  standalone: true,
  templateUrl: './broadband-filters.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    FiltersInputComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class BroadbandFilters {
  private readonly broadbandStore = inject(BroadbandStore);

  readonly query = input<BroadbandRecordQuery>({});
  readonly queryChange = output<BroadbandRecordQuery>();

  readonly filters: { id: string, name: string, type: 'number' | 'text' }[] = [
    {
      id: 'zipCode',
      name: 'Zip Code',
      type: 'text',
    }, {
      id: 'maxHomeBroadbandAdoption',
      name: 'Max Home Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'minHomeBroadbandAdoption',
      name: 'Min Home Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'maxMobileBroadbandAdoption',
      name: 'Max Mobile Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'minMobileBroadbandAdoption',
      name: 'Min Mobile Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'maxNoInternetAccessPercentage',
      name: 'Max No Internet Access Percentage',
      type: 'number',
    }, {
      id: 'minNoInternetAccessPercentage',
      name: 'Min No Internet Access Percentage',
      type: 'number',
    }, {
      id: 'maxNoHomeBroadbandAdoption',
      name: 'Max No Home Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'minNoHomeBroadbandAdoption',
      name: 'Min No Home Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'maxNoMobileBroadbandAdoption',
      name: 'Max No Mobile Broadband Adoption Percentage',
      type: 'number',
    }, {
      id: 'minNoMobileBroadbandAdoption',
      name: 'Min No Mobile Broadband Adoption Percentage',
      type: 'number'
    }
  ]

  filterRecords() {
    // TODO:
    // Get filter data and send for new records
    this.broadbandStore.loadRecords()
  }
}
