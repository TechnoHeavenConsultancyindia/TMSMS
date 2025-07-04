import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { SERVICE_TYPE_BASE_ROUTES } from './service-type-base.routes';

export const COMMON_SERVICES_SERVICE_TYPE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...SERVICE_TYPE_BASE_ROUTES];
  routesService.add(routes);
}
