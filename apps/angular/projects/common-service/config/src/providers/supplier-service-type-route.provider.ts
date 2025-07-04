import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { SUPPLIER_SERVICE_TYPE_BASE_ROUTES } from './supplier-service-type-base.routes';

export const COMMON_SERVICES_SUPPLIER_SERVICE_TYPE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...SUPPLIER_SERVICE_TYPE_BASE_ROUTES];
  routesService.add(routes);
}
