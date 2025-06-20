import { ModuleWithProviders, NgModule } from '@angular/core';
import { VISA_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class VisaServiceConfigModule {
  static forRoot(): ModuleWithProviders<VisaServiceConfigModule> {
    return {
      ngModule: VisaServiceConfigModule,
      providers: [VISA_SERVICE_ROUTE_PROVIDERS],
    };
  }
}
