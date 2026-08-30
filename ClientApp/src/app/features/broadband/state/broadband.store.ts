import {inject, Injectable, signal} from '@angular/core';

import { BroadbandRecord } from '@broadband/models/broadband-record';
import { BroadbandRecordQuery } from '@broadband/models/broadband-record-query';
import { BroadbandStatus } from '@broadband/models/broadband-status';
import { BroadbandApi } from '@app/core/api/broadband-api.service';
import {catchError, EMPTY, finalize, Observable, tap, throwError} from 'rxjs';
import {BroadbandSummary} from '@broadband/models/broadband-summary';

@Injectable({
  providedIn: 'root'
})
export class BroadbandStore {
  private readonly api = inject(BroadbandApi);

  readonly status = signal<BroadbandStatus | null>(null);

  readonly records = signal<BroadbandRecord[]>([]);

  readonly summary = signal<BroadbandSummary | null>(null);

  readonly query = signal<BroadbandRecordQuery>({});

  readonly loading = signal(false);

  readonly error = signal<string | null>(null);


  checkStatusLoaded(): void {
    if (this.status() !== null || this.loading()) {
      return;
    }

    this.getStatus();
  }

  clear(): Observable<BroadbandStatus> {
    this.loading.set(true);
    this.error.set(null);

    return this.api.reset().pipe(
      tap(status => {
        if (!status.hasImportedData) {
          this.status.set(null);
          this.records.set([]);
          this.summary.set(null)
          this.query.set({});
          this.loading.set(false);
          this.error.set(null);
        }
      }),
      catchError(error => {
        this.error.set('Unable to import broadband data.');
        return throwError(() => error);
      }),
      finalize(() => this.loading.set(false))
    )
  }

  getStatus(): Observable<BroadbandStatus> {
    this.loading.set(true);
    this.error.set(null);

    return this.api.getStatus().pipe(
      tap(status => {
        this.status.set(status);
      }),
      catchError(error => {
        this.error.set('Unable to get broadband status.');
        return throwError(() => error);
      }),
      finalize(() => this.loading.set(false))
    );
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

  loadRecords(): void {
    this.loading.set(true);
    this.error.set(null);

    this.api.getRecords().pipe(
      tap(records => {
        this.records.set(records);
      }),
      catchError(error => {
        this.error.set('Unable to import broadband data.');
        return EMPTY;
      }),
      finalize(() => {
        this.loading.set(false);
      })
    ).subscribe();
  }

  loadSummary(): void {
    this.loading.set(true);
    this.error.set(null);

    this.api.getSummary().pipe(
      tap(summary => {
        this.summary.set(summary);
      }),
      catchError(error => {
        this.error.set('Unable to import broadband data.');
        return EMPTY;
      }),
      finalize(() => {
        this.loading.set(false);
      })
    ).subscribe();
  }

  // TODO:
  // updateQuery()
  // loadSummary()
  // export()
}
