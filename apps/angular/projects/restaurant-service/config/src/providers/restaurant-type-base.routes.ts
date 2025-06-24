import { ABP, eLayoutType } from '@abp/ng.core';

import { eRestaurantServiceRouteNames } from '../enums/route-names';

export const RESTAURANT_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/restaurant-service/restaurant-types',
    parentName: eRestaurantServiceRouteNames.RestaurantService,
    name: 'RestaurantService::Menu:RestaurantTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'RestaurantService.RestaurantTypes',
    breadcrumbText: 'RestaurantService::RestaurantType',
  },
];
