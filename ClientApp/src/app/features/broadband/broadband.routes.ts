import { Routes } from '@angular/router';

import { broadbandNotImportedGuard } from '@broadband/guards/broadband-not-imported.guard';
import { broadbandRequiredGuard } from '@broadband/guards/broadband-required.guard';

export const BROADBAND_ROUTES: Routes = [
  {
    path: '',
    canActivate: [broadbandNotImportedGuard],
    loadComponent: () =>
      import('@app/layout/site-layout/site-layout')
        .then(m => m.SiteLayout),
    children: [
      {
        path: 'import',
        loadComponent: () =>
          import('@broadband/import/import.page')
            .then(m => m.ImportPage)
      }
    ],
  },
  {
    path: '',
    canActivate: [broadbandRequiredGuard],
    loadComponent: () =>
      import('@app/layout/site-layout/site-layout')
        .then(m => m.SiteLayout),
    children: [
      {
        path: 'records',
        loadComponent: () =>
          import('@broadband/records/records.page')
            .then(m => m.RecordsPage)
      },
      {
        path: 'records/summary',
        loadComponent: () =>
          import('@broadband/records/summary/summary.page')
            .then(m => m.SummaryPage)
      },
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'records'
      }
    ]
  }
];
