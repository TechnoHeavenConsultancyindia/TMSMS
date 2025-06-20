import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CommonServiceRoutingModule } from './common-service-routing.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, CommonServiceRoutingModule],
  exports: [],
})
export class CommonServiceModule {
  static forChild(): ModuleWithProviders<CommonServiceModule> {
    return {
      ngModule: CommonServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CommonServiceModule> {
    return new LazyModuleFactory(CommonServiceModule.forChild());
  }
}
