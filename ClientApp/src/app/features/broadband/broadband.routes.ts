import { Routes } from '@angular/router';

import { broadbandNotImportedGuard } from '@broadband/guards/broadband-not-imported.guard';
import { broadbandRequiredGuard } from '@broadband/guards/broadband-required.guard';

export const BROADBAND_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('@app/layout/site-layout/site-layout')
        .then(m => m.SiteLayout),

    children: [
      {
        path: 'import',
        canActivate: [broadbandNotImportedGuard],
        loadComponent: () =>
          import('@broadband/import/import.page')
            .then(m => m.ImportPage)
      },
      {
        path: 'records',
        canActivate: [broadbandRequiredGuard],
        loadComponent: () =>
          import('@broadband/records/records.page')
            .then(m => m.RecordsPage)
      },
      {
        path: 'records/summary',
        canActivate: [broadbandRequiredGuard],
        loadComponent: () =>
          import('@broadband/records/summary/summary.page')
            .then(m => m.SummaryPage)
      },
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'import'
      }
    ]
  }
];
