import { ABP, eLayoutType } from '@abp/ng.core';

import { eTransferServiceRouteNames } from '../enums/route-names';

export const TRANSFER_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/transfer-service/transfer-types',
    parentName: eTransferServiceRouteNames.TransferService,
    name: 'TransferService::Menu:TransferTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'TransferService.TransferTypes',
    breadcrumbText: 'TransferService::TransferTypes',
  },
];
