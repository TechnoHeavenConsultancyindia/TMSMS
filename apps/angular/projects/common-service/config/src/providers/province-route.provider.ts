import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { PROVINCE_BASE_ROUTES } from './province-base.routes';

export const COMMON_SERVICES_PROVINCE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...PROVINCE_BASE_ROUTES];
  routesService.add(routes);
}
