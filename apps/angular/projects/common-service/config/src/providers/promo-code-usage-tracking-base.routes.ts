import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const PROMO_CODE_USAGE_TRACKING_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/promo-code-usage-trackings',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:PromoCodeUsageTrackings',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.PromoCodeUsageTrackings',
    breadcrumbText: 'CommonService::PromoCodeUsageTrackings',
  },
];
