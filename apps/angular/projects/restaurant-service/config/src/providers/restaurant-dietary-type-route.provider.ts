import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { RESTAURANT_DIETARY_TYPE_BASE_ROUTES } from './restaurant-dietary-type-base.routes';

export const RESTAURANT_SERVICES_RESTAURANT_DIETARY_TYPE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...RESTAURANT_DIETARY_TYPE_BASE_ROUTES];
  routesService.add(routes);
}
