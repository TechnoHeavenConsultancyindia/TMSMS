import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const PROVINCE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/provinces',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:Provinces',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.Provinces',
    breadcrumbText: 'CommonService::Provinces',
  },
];
