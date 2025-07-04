import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const SUPPLIER_MASTER_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/supplier-masters',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:SupplierMasters',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.SupplierMasters',
    breadcrumbText: 'CommonService::SupplierMasters',
  },
];
