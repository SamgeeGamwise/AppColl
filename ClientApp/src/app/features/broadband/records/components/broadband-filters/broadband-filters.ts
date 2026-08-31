import {
  ChangeDetectionStrategy,
  Component, CUSTOM_ELEMENTS_SCHEMA, effect, ElementRef, inject,
  input,
  output, viewChild
} from '@angular/core';

import {BroadbandRecordQuery} from '@broadband/models/broadband-record-query';
import {
  FiltersInputComponent
} from '@broadband/records/components/broadband-filters/components/filters-input/filters-input-component';
import {BroadbandStore} from '@broadband/state/broadband.store';
import {FormControl, FormGroup} from '@angular/forms';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';

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
  readonly drawer = viewChild.required<ElementRef<HTMLDialogElement>>('drawer');
  private readonly broadbandStore = inject(BroadbandStore);
  readonly query = input<BroadbandRecordQuery>();
  readonly queryChange = output<BroadbandRecordQuery>();
  readonly type = input("records");

  readonly filterForm = new FormGroup({
    zipCode: new FormControl<string | null>(null),

    maxHomeBroadbandAdoption: new FormControl<number | null>(null),
    minHomeBroadbandAdoption: new FormControl<number | null>(null),

    maxMobileBroadbandAdoption: new FormControl<number | null>(null),
    minMobileBroadbandAdoption: new FormControl<number | null>(null),

    maxNoInternetAccessPercentage: new FormControl<number | null>(null),
    minNoInternetAccessPercentage: new FormControl<number | null>(null),

    maxNoHomeBroadbandAdoption: new FormControl<number | null>(null),
    minNoHomeBroadbandAdoption: new FormControl<number | null>(null),

    maxNoMobileBroadbandAdoption: new FormControl<number | null>(null),
    minNoMobileBroadbandAdoption: new FormControl<number | null>(null),
  });

  readonly filters: filtersInput[] = [
    {
      id: 'zipCode',
      name: 'Zip Code',
      type: 'text',
    }, {
      id: 'maxHomeBroadbandAdoption',
      name: 'Max Home Broadband Adoption',
      type: 'number',
    }, {
      id: 'minHomeBroadbandAdoption',
      name: 'Min Home Broadband Adoption',
      type: 'number',
    }, {
      id: 'maxMobileBroadbandAdoption',
      name: 'Max Mobile Broadband Adoption',
      type: 'number',
    }, {
      id: 'minMobileBroadbandAdoption',
      name: 'Min Mobile Broadband Adoption',
      type: 'number',
    }, {
      id: 'maxNoInternetAccessPercentage',
      name: 'Max No Internet Access',
      type: 'number',
    }, {
      id: 'minNoInternetAccessPercentage',
      name: 'Min No Internet Access',
      type: 'number',
    }, {
      id: 'maxNoHomeBroadbandAdoption',
      name: 'Max No Home Broadband Adoption',
      type: 'number',
    }, {
      id: 'minNoHomeBroadbandAdoption',
      name: 'Min No Home Broadband Adoption',
      type: 'number',
    }, {
      id: 'maxNoMobileBroadbandAdoption',
      name: 'Max No Mobile Broadband Adoption',
      type: 'number',
    }, {
      id: 'minNoMobileBroadbandAdoption',
      name: 'Min No Mobile Broadband Adoption',
      type: 'number'
    }
  ]

  constructor() {
    this.filterForm.valueChanges
      .pipe(takeUntilDestroyed())
      .subscribe(() => {
        this.broadbandStore.query.set(this.filterForm.getRawValue());
      });
  }

  filterRecords() {
    this.drawer().nativeElement.close();

    if (this.type() === 'records') {
      this.broadbandStore.loadRecords()
    } else if (this.type() === 'summary') {
      this.broadbandStore.loadSummary()
    }
  }
  clearFilter() {
    this.filterForm.reset();

    if (this.type() === 'records') {
      this.broadbandStore.loadRecords()
    } else if (this.type() === 'summary') {
      this.broadbandStore.loadSummary()
    }
  }

}

interface filtersInput {
  id: keyof BroadbandRecordQuery;
  name: string;
  type: 'number' | 'text';
}
