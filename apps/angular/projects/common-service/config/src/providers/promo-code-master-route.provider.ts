import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { PROMO_CODE_MASTER_BASE_ROUTES } from './promo-code-master-base.routes';

export const COMMON_SERVICES_PROMO_CODE_MASTER_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...PROMO_CODE_MASTER_BASE_ROUTES];
  routesService.add(routes);
}
