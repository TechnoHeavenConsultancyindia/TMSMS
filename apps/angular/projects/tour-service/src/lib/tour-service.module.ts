import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { TourServiceRoutingModule } from './tour-service-routing.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, TourServiceRoutingModule],
  exports: [],
})
export class TourServiceModule {
  static forChild(): ModuleWithProviders<TourServiceModule> {
    return {
      ngModule: TourServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<TourServiceModule> {
    return new LazyModuleFactory(TourServiceModule.forChild());
  }
}
