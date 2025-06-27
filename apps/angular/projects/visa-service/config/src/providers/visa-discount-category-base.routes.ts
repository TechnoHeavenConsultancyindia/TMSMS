import { ABP, eLayoutType } from '@abp/ng.core';

import { eVisaServiceRouteNames } from '../enums/route-names';

export const VISA_DISCOUNT_CATEGORY_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/visa-service/visa-discount-categories',
    parentName: eVisaServiceRouteNames.VisaService,
    name: 'VisaService::Menu:VisaDiscountCategories',
    layout: eLayoutType.application,
    requiredPolicy: 'VisaService.VisaDiscountCategories',
    breadcrumbText: 'VisaService::DiscountCategories',
  },
];
