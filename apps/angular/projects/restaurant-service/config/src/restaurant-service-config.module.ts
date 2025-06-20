import { ModuleWithProviders, NgModule } from '@angular/core';
import { RESTAURANT_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class RestaurantServiceConfigModule {
  static forRoot(): ModuleWithProviders<RestaurantServiceConfigModule> {
    return {
      ngModule: RestaurantServiceConfigModule,
      providers: [RESTAURANT_SERVICE_ROUTE_PROVIDERS],
    };
  }
}
