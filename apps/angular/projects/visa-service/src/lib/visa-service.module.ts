import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { VisaServiceRoutingModule } from './visa-service-routing.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, VisaServiceRoutingModule],
  exports: [],
})
export class VisaServiceModule {
  static forChild(): ModuleWithProviders<VisaServiceModule> {
    return {
      ngModule: VisaServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<VisaServiceModule> {
    return new LazyModuleFactory(VisaServiceModule.forChild());
  }
}
