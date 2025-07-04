import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const WEEK_DAY_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/week-days',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:WeekDays',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.WeekDays',
    breadcrumbText: 'CommonService::WeekDays',
  },
];
