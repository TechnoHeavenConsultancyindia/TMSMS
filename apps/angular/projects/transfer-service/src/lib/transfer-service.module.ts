import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { TransferServiceRoutingModule } from './transfer-service-routing.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, TransferServiceRoutingModule],
  exports: [],
})
export class TransferServiceModule {
  static forChild(): ModuleWithProviders<TransferServiceModule> {
    return {
      ngModule: TransferServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<TransferServiceModule> {
    return new LazyModuleFactory(TransferServiceModule.forChild());
  }
}
