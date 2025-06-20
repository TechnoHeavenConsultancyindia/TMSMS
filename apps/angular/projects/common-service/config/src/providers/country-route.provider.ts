import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { COUNTRY_BASE_ROUTES } from './country-base.routes';

export const COMMON_SERVICES_COUNTRY_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...COUNTRY_BASE_ROUTES];
  routesService.add(routes);
}
