import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const CITY_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/cities',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:Cities',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.Cities',
    breadcrumbText: 'CommonService::City',
  },
];
