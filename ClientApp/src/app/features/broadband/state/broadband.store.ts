import {inject, Injectable, signal} from '@angular/core';

import { BroadbandRecord } from '@broadband/models/broadband-record';
import { BroadbandRecordQuery } from '@broadband/models/broadband-record-query';
import { BroadbandStatus } from '@broadband/models/broadband-status';
import { BroadbandApi } from '@app/core/api/broadband-api.service';
import {catchError, finalize, Observable, tap, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BroadbandStore {
  private readonly api = inject(BroadbandApi);

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

  initialize(): void {

  }

  importData(): Observable<BroadbandStatus> {
    this.loading.set(true);
    this.error.set(null);

    return this.api.importData().pipe(
      tap(status => this.status.set(status)),
      catchError(error => {
        this.error.set('Unable to import broadband data.');
        return throwError(() => error);
      }),
      finalize(() => this.loading.set(false))
    )
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
