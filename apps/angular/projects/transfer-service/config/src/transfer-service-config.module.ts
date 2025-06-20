import { ModuleWithProviders, NgModule } from '@angular/core';
import { TRANSFER_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';
import { TRANSFER_SERVICES_TRANSFER_TYPE_ROUTE_PROVIDER } from './providers/transfer-type-route.provider';

@NgModule()
export class TransferServiceConfigModule {
  static forRoot(): ModuleWithProviders<TransferServiceConfigModule> {
    return {
      ngModule: TransferServiceConfigModule,
      providers: [
        TRANSFER_SERVICE_ROUTE_PROVIDERS,
        TRANSFER_SERVICES_TRANSFER_TYPE_ROUTE_PROVIDER,
      ],
    };
  }
}
