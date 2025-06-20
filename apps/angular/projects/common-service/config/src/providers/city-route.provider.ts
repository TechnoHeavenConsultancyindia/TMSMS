import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { CITY_BASE_ROUTES } from './city-base.routes';

export const COMMON_SERVICES_CITY_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...CITY_BASE_ROUTES];
  routesService.add(routes);
}
