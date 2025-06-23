import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { RESTAURANT_TYPE_BASE_ROUTES } from './restaurant-type-base.routes';

export const RESTAURANT_SERVICES_RESTAURANT_TYPE_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...RESTAURANT_TYPE_BASE_ROUTES];
    routesService.add(routes);
  };
}
