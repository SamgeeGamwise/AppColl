import { CanActivateFn } from '@angular/router';

export const broadbandRequiredGuard: CanActivateFn = () => {
  // TODO:
  // Check BroadbandStore / GET /status.
  //
  // If imported:
  // return true;
  //
  // Otherwise:
  // return router.createUrlTree(['/import']);

  return true;
};
