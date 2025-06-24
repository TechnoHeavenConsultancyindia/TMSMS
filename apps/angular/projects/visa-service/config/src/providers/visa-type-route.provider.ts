import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { VISA_TYPE_BASE_ROUTES } from './visa-type-base.routes';

export const VISA_SERVICES_VISA_TYPE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...VISA_TYPE_BASE_ROUTES];
  routesService.add(routes);
}
