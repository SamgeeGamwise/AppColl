import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('@broadband/broadband.routes')
        .then(m => m.BROADBAND_ROUTES)
  },
  {
    path: '**',
    redirectTo: ''
  }
];
