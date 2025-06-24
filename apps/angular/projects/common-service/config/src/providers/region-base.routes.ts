import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const REGION_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/regions',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:Regions',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.Regions',
    breadcrumbText: 'CommonService::Regions',
  },
];
