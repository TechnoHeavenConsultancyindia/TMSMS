import { ABP, eLayoutType } from '@abp/ng.core';

import { eAgentServiceRouteNames } from '../enums/route-names';

export const AGENT_PERMISSION_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/agent-service/agent-permission-types',
    parentName: eAgentServiceRouteNames.AgentService,
    name: 'AgentService::Menu:AgentPermissionTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'AgentService.AgentPermissionTypes',
    breadcrumbText: 'AgentService::AgentPermissionTypes',
  },
];
