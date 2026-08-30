import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BroadbandRecord } from '@broadband/models/broadband-record';
import { BroadbandStatus } from '@broadband/models/broadband-status';
import { BroadbandSummary } from '@broadband/models/broadband-summary';

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

  getRecords(): Observable<BroadbandRecord[]> {
    return this.http.get<BroadbandRecord[]>(
      `${this.baseUrl}/records`
    );
  }

  getSummary(): Observable<BroadbandSummary> {
    return this.http.get<BroadbandSummary>(
      `${this.baseUrl}/summary`
    );
  }

  reset(): Observable<BroadbandStatus> {
    return this.http.post<BroadbandStatus>(
      `${this.baseUrl}/reset`,
      null
    );
  }

  // TODO:
  // getRecords(query)
  // getSummary(query)
  // export(format, query)
}
