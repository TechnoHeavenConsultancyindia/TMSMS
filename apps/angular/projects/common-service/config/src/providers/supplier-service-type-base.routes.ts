import { ABP, eLayoutType } from '@abp/ng.core';

import { eCommonServiceRouteNames } from '../enums/route-names';

export const SUPPLIER_SERVICE_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/common-service/supplier-service-types',
    parentName: eCommonServiceRouteNames.CommonService,
    name: 'CommonService::Menu:SupplierServiceTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'CommonService.SupplierServiceTypes',
    breadcrumbText: 'CommonService::SupplierServiceTypes',
  },
];
