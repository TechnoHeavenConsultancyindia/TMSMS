import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { RESTAURANT_TAG_BASE_ROUTES } from './restaurant-tag-base.routes';

export const RESTAURANT_SERVICES_RESTAURANT_TAG_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...RESTAURANT_TAG_BASE_ROUTES];
  routesService.add(routes);
}
