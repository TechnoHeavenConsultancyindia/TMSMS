import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { REGION_BASE_ROUTES } from './region-base.routes';

export const COMMON_SERVICES_REGION_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...REGION_BASE_ROUTES];
  routesService.add(routes);
}
