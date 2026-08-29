import { Injectable, signal } from '@angular/core';

import { BroadbandRecord } from '../models/broadband-record';
import { BroadbandRecordQuery } from '../models/broadband-record-query';
import { BroadbandStatus } from '../models/broadband-status';

@Injectable({
  providedIn: 'root'
})
export class BroadbandStore {
  readonly status = signal<BroadbandStatus | null>(null);

  readonly records = signal<BroadbandRecord[]>([]);

  readonly query = signal<BroadbandRecordQuery>({});

  readonly loading = signal(false);

  readonly error = signal<string | null>(null);

  clear(): void {
    this.status.set(null);
    this.records.set([]);
    this.query.set({});
    this.loading.set(false);
    this.error.set(null);
  }

  // TODO:
  // initialize()
  // importData()
  // loadRecords()
  // updateQuery()
  // loadSummary()
  // export()
  // reset()
}
