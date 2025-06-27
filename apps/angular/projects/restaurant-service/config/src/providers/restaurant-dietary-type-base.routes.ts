import { ABP, eLayoutType } from '@abp/ng.core';

import { eRestaurantServiceRouteNames } from '../enums/route-names';

export const RESTAURANT_DIETARY_TYPE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/restaurant-service/restaurant-dietary-types',
    parentName: eRestaurantServiceRouteNames.RestaurantService,
    name: 'RestaurantService::Menu:RestaurantDietaryTypes',
    layout: eLayoutType.application,
    requiredPolicy: 'RestaurantService.RestaurantDietaryTypes',
    breadcrumbText: 'RestaurantService::RestaurantDietaryType',
  },
];
