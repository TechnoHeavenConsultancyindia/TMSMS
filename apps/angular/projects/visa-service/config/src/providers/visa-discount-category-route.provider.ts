import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { VISA_DISCOUNT_CATEGORY_BASE_ROUTES } from './visa-discount-category-base.routes';

export const VISA_SERVICES_VISA_DISCOUNT_CATEGORY_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...VISA_DISCOUNT_CATEGORY_BASE_ROUTES];
  routesService.add(routes);
}
