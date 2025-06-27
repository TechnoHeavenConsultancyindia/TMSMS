import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { VISA_TERM_CATEGORY_BASE_ROUTES } from './visa-term-category-base.routes';

export const VISA_SERVICES_VISA_TERM_CATEGORY_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...VISA_TERM_CATEGORY_BASE_ROUTES];
  routesService.add(routes);
}
