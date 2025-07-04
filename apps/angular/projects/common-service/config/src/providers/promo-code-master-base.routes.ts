import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const PROMO_CODE_MASTER_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/promo-code-masters',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:PromoCodeMasters',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.PromoCodeMasters',
    breadcrumbText: 'CommonService::PromoCodeMasters',
  },
];
