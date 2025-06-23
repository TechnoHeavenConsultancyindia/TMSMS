import { ABP, eLayoutType } from '@abp/ng.core';

import { eAgentServiceRouteNames } from '../enums/route-names';

export const AGENT_VOUCHER_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/agent-service/agent-voucher-types',
    parentName: eAgentServiceRouteNames.AgentService,
    name: 'AgentService::Menu:AgentVoucherTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'AgentService.AgentVoucherTypes',
    breadcrumbText: 'AgentService::AgentVoucherTypes',
  },
];
