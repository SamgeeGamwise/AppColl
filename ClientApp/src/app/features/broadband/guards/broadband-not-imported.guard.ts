import {CanActivateFn, Router} from '@angular/router';
import {inject} from '@angular/core';
import {BroadbandStore} from '@broadband/state/broadband.store';
import {catchError, map, of} from 'rxjs';

export const broadbandNotImportedGuard: CanActivateFn = () => {
  const store = inject(BroadbandStore);
  const router = inject(Router);

  const status = store.status();

  if (status !== null) {
    return status.hasImportedData
      ? router.createUrlTree(['/records'])
      : true;
  }

  return store.getStatus().pipe(
    map(status =>
      status.hasImportedData
        ? router.createUrlTree(['/records'])
        : true
    ),
    catchError(() =>
      of(router.createUrlTree(['/records']))
    )
  );
};
