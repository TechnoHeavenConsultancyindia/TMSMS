import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { PROMO_CODE_USAGE_TRACKING_BASE_ROUTES } from './promo-code-usage-tracking-base.routes';

export const COMMON_SERVICES_PROMO_CODE_USAGE_TRACKING_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...PROMO_CODE_USAGE_TRACKING_BASE_ROUTES];
  routesService.add(routes);
}
