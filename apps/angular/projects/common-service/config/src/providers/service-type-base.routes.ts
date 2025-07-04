import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const SERVICE_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/service-types',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:ServiceTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.ServiceTypes',
    breadcrumbText: 'CommonService::ServiceTypes',
  },
];
