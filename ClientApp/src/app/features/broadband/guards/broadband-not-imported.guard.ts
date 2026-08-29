import { CanActivateFn } from '@angular/router';

export const broadbandNotImportedGuard: CanActivateFn = () => {
  // TODO:
  // Check BroadbandStore / GET /status.
  //
  // If not imported:
  // return true;
  //
  // Otherwise:
  // return router.createUrlTree(['/data']);

  return true;
};
