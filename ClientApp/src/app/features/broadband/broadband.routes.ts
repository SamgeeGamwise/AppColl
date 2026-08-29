import { Routes } from '@angular/router';

import { broadbandNotImportedGuard } from './guards/broadband-not-imported.guard';
import { broadbandRequiredGuard } from './guards/broadband-required.guard';

export const BROADBAND_ROUTES: Routes = [
  {
    path: 'import',
    canActivate: [broadbandNotImportedGuard],
    loadComponent: () =>
      import('./import/import.page')
        .then(m => m.ImportPage)
  },
  {
    path: '',
    canActivate: [broadbandRequiredGuard],
    loadComponent: () =>
      import('../../layout/site-layout/site-layout')
        .then(m => m.SiteLayout),
    children: [
      {
        path: 'data',
        loadComponent: () =>
          import('./data/data.page')
            .then(m => m.DataPage)
      },
      {
        path: 'summary',
        loadComponent: () =>
          import('./summary/summary.page')
            .then(m => m.SummaryPage)
      },
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'data'
      }
    ]
  }
];
