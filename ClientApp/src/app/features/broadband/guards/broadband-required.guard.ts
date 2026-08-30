import {CanActivateFn, Router} from '@angular/router';
import {inject} from '@angular/core';
import {BroadbandStore} from '@broadband/state/broadband.store';

export const broadbandRequiredGuard: CanActivateFn = () => {
  const store = inject(BroadbandStore);
  const router = inject(Router);

  return store.status()?.hasImportedData ? true : router.createUrlTree(['/import'])
};
