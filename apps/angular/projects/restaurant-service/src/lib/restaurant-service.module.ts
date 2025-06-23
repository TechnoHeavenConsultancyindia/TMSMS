import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { RestaurantServiceRoutingModule } from './restaurant-service-routing.module';
//import { RESTAURANT_SERVICES_RESTAURANT_TYPE_ROUTE_PROVIDER } from './restaurant-services/restaurant-type/providers/restaurant-type-route.provider';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, RestaurantServiceRoutingModule],
  exports: [],
  //providers: [RESTAURANT_SERVICES_RESTAURANT_TYPE_ROUTE_PROVIDER],
})
export class RestaurantServiceModule {
  static forChild(): ModuleWithProviders<RestaurantServiceModule> {
    return {
      ngModule: RestaurantServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<RestaurantServiceModule> {
    return new LazyModuleFactory(RestaurantServiceModule.forChild());
  }
}
