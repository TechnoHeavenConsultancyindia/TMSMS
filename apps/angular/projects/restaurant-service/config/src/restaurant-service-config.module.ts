import { ModuleWithProviders, NgModule } from '@angular/core';
import { RESTAURANT_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';
import { RESTAURANT_SERVICES_RESTAURANT_TYPE_ROUTE_PROVIDER } from './providers/restaurant-type-route.provider';
import { RESTAURANT_SERVICES_RESTAURANT_TAG_ROUTE_PROVIDER } from './providers/restaurant-tag-route.provider';
import { RESTAURANT_SERVICES_RESTAURANT_DIETARY_TYPE_ROUTE_PROVIDER } from './providers/restaurant-dietary-type-route.provider';

@NgModule()
export class RestaurantServiceConfigModule {
  static forRoot(): ModuleWithProviders<RestaurantServiceConfigModule> {
    return {
      ngModule: RestaurantServiceConfigModule,
      providers: [
        RESTAURANT_SERVICE_ROUTE_PROVIDERS,
        RESTAURANT_SERVICES_RESTAURANT_TYPE_ROUTE_PROVIDER,
        RESTAURANT_SERVICES_RESTAURANT_TAG_ROUTE_PROVIDER,
        RESTAURANT_SERVICES_RESTAURANT_DIETARY_TYPE_ROUTE_PROVIDER,
      ],
    };
  }
}
