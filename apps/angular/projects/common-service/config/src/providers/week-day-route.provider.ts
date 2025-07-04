import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { WEEK_DAY_BASE_ROUTES } from './week-day-base.routes';

export const COMMON_SERVICES_WEEK_DAY_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...WEEK_DAY_BASE_ROUTES];
  routesService.add(routes);
}
