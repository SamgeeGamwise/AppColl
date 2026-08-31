import { inject, Injectable } from '@angular/core';
import {HttpClient, HttpParams, HttpResponse} from '@angular/common/http';
import { Observable } from 'rxjs';

import { BroadbandRecord } from '@broadband/models/broadband-record';
import { BroadbandStatus } from '@broadband/models/broadband-status';
import { BroadbandSummary } from '@broadband/models/broadband-summary';
import {BroadbandRecordQuery} from '@broadband/models/broadband-record-query';
import {BroadbandExportFormat} from '@broadband/models/broadband-export-format';

@Injectable({
  providedIn: 'root'
})
export class BroadbandApi {
  private readonly http = inject(HttpClient);

  private readonly baseUrl = '/api/broadband';

  importData(): Observable<BroadbandStatus> {
    return this.http.post<BroadbandStatus>(
      `${this.baseUrl}/import`,
      null
    );
  }

  getStatus(): Observable<BroadbandStatus> {
    return this.http.get<BroadbandStatus>(
      `${this.baseUrl}/status`
    );
  }

  getRecords(query: BroadbandRecordQuery | null): Observable<BroadbandRecord[]> {
    let params = new HttpParams();

    if (query) {
      Object.entries(query).forEach(([key, value]) => {
        if (value !== undefined && value !== null) {
          params = params.set(key, value.toString());
        }
      });
    }

    return this.http.get<BroadbandRecord[]>(`${this.baseUrl}/records`, { params });
  }

  getSummary(query: BroadbandRecordQuery | null): Observable<BroadbandSummary> {
    let params = new HttpParams();

    if (query) {
      Object.entries(query).forEach(([key, value]) => {
        if (value !== undefined && value !== null) {
          params = params.set(key, value.toString());
        }
      });
    }

    return this.http.get<BroadbandSummary>(`${this.baseUrl}/summary`, { params });
  }

  reset(): Observable<BroadbandStatus> {
    return this.http.post<BroadbandStatus>(
      `${this.baseUrl}/reset`,
      null
    );
  }

  export(format: BroadbandExportFormat, query: BroadbandRecordQuery | null): Observable<HttpResponse<Blob>>   {
    let params = new HttpParams()
      .set('format', format);

    if (query) {
      Object.entries(query).forEach(([key, value]) => {
        if (value !== undefined && value !== null) {
          params = params.set(key, value.toString());
        }
      });
    }

    return this.http.get('/api/broadband/export', {
      params,
      observe: 'response',
      responseType: 'blob'
    });
  }
}
