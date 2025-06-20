import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { RestaurantServiceRoutingModule } from './restaurant-service-routing.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, RestaurantServiceRoutingModule],
  exports: [],
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
