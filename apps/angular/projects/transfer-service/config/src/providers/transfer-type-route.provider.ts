import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { TRANSFER_TYPE_BASE_ROUTES } from './transfer-type-base.routes';

export const TRANSFER_SERVICES_TRANSFER_TYPE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...TRANSFER_TYPE_BASE_ROUTES];
  routesService.add(routes);
}
