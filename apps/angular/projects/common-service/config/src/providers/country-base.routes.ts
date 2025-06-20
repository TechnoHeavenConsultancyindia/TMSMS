import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const COUNTRY_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/countries',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:Countries',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.Countries',
    breadcrumbText: 'CommonService::Countries',
  },
];
