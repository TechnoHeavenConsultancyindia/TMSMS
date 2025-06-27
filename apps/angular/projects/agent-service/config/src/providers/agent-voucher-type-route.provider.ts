import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { AGENT_VOUCHER_TYPE_BASE_ROUTES } from './agent-voucher-type-base.routes';

export const AGENT_SERVICES_AGENT_VOUCHER_TYPE_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...AGENT_VOUCHER_TYPE_BASE_ROUTES];
  routesService.add(routes);
}
