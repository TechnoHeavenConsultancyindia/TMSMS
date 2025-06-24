import { ABP, eLayoutType } from '@abp/ng.core';

import { eVisaServiceRouteNames } from '../enums/route-names';

export const VISA_TERM_CATEGORY_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/visa-service/visa-term-categories',
    parentName: eVisaServiceRouteNames.VisaService,
    name: 'VisaService::Menu:VisaTermCategories',
    layout: eLayoutType.application,
    requiredPolicy: 'VisaService.VisaTermCategories',
    breadcrumbText: 'VisaService::VisaTermCategories',
  },
];
