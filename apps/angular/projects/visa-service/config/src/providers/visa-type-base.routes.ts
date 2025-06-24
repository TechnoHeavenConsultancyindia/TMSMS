import { ABP, eLayoutType } from '@abp/ng.core';

import { eVisaServiceRouteNames } from '../enums/route-names';

export const VISA_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/visa-service/visa-types',
    parentName: eVisaServiceRouteNames.VisaService,
    name: 'VisaService::Menu:VisaTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'VisaService.VisaTypes',
    breadcrumbText: 'VisaService::VisaTypes',
  },
];
