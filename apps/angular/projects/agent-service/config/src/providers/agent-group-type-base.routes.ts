import { ABP, eLayoutType } from '@abp/ng.core';

import { eAgentServiceRouteNames } from '../enums/route-names';

export const AGENT_GROUP_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/agent-service/agent-group-types',
    parentName: eAgentServiceRouteNames.AgentService,
    name: 'AgentService::Menu:AgentGroupTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'AgentService.AgentGroupTypes',
    breadcrumbText: 'AgentService::AgentGroupTypes',
  },
];
