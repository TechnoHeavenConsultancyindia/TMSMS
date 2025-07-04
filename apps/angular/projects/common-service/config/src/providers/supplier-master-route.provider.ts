import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { SUPPLIER_MASTER_BASE_ROUTES } from './supplier-master-base.routes';

export const COMMON_SERVICES_SUPPLIER_MASTER_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...SUPPLIER_MASTER_BASE_ROUTES];
  routesService.add(routes);
}
