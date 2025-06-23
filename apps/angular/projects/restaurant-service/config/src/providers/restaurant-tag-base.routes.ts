import { ABP, eLayoutType } from '@abp/ng.core';

import { eRestaurantServiceRouteNames } from '../enums/route-names';

export const RESTAURANT_TAG_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/restaurant-service/restaurant-tags',
    parentName: eRestaurantServiceRouteNames.RestaurantService,
    name: 'RestaurantService::Menu:RestaurantTags',
    layout: eLayoutType.application,
    requiredPolicy: 'RestaurantService.RestaurantTags',
    breadcrumbText: 'RestaurantService::RestaurantTag',
  },
];
