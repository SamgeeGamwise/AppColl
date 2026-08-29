import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./features/broadband/broadband.routes')
        .then(m => m.BROADBAND_ROUTES)
  },
  {
    path: '**',
    redirectTo: ''
  }
];
