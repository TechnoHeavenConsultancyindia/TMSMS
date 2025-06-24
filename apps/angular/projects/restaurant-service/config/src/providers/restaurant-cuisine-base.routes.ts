import { ABP, eLayoutType } from '@abp/ng.core';

import { eRestaurantServiceRouteNames } from '../enums/route-names';

export const RESTAURANT_CUISINE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/restaurant-service/restaurant-cuisines',
    parentName: eRestaurantServiceRouteNames.RestaurantService,
    name: 'RestaurantService::Menu:RestaurantCuisines',
    layout: eLayoutType.application,
    requiredPolicy: 'RestaurantService.RestaurantCuisines',
    breadcrumbText: 'RestaurantService::RestaurantCuisine',
  },
];
