import { inject, provideAppInitializer } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { AGENT_FINANCE_DETAIL_BASE_ROUTES } from './agent-finance-detail-base.routes';

export const AGENT_SERVICES_AGENT_FINANCE_DETAIL_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routesService = inject(RoutesService);
  const routes: ABP.Route[] = [...AGENT_FINANCE_DETAIL_BASE_ROUTES];
  routesService.add(routes);
}
