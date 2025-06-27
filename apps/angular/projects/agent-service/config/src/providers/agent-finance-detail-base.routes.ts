import { ABP, eLayoutType } from '@abp/ng.core';

import { eAgentServiceRouteNames } from '../enums/route-names';

export const AGENT_FINANCE_DETAIL_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/agent-service/agent-finance-details',
    parentName: eAgentServiceRouteNames.AgentService,
    name: 'AgentService::Menu:AgentFinanceDetails',
    layout: eLayoutType.application,
    requiredPolicy: 'AgentService.AgentFinanceDetails',
    breadcrumbText: 'AgentService::AgentFinanceDetails',
  },
];
