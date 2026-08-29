import { Routes } from '@angular/router';
import { SiteLayout } from './layout/site-layout/site-layout';

export const routes: Routes = [
  {
    path: 'broadband',
    loadComponent: () =>
      import('./features/broadband/broadband.page')
        .then(m => m.BroadbandPage)
  },
  {
    path: 'summary',
    loadComponent: () =>
      import('./features/summary/summary.page')
        .then(m => m.SummaryPage)
  },
  {
    path: 'export',
    loadComponent: () =>
      import('./features/export/export.page')
        .then(m => m.ExportPage)
  }
];
