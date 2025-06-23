import { ModuleWithProviders, NgModule } from '@angular/core';
import { VISA_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';
import { VISA_SERVICES_VISA_TERM_CATEGORY_ROUTE_PROVIDER } from './providers/visa-term-category-route.provider';
import { VISA_SERVICES_VISA_TYPE_ROUTE_PROVIDER } from './providers/visa-type-route.provider';
import { VISA_SERVICES_VISA_DISCOUNT_CATEGORY_ROUTE_PROVIDER } from './providers/visa-discount-category-route.provider';

@NgModule()
export class VisaServiceConfigModule {
  static forRoot(): ModuleWithProviders<VisaServiceConfigModule> {
    return {
      ngModule: VisaServiceConfigModule,
      providers: [
        VISA_SERVICE_ROUTE_PROVIDERS,
        VISA_SERVICES_VISA_TERM_CATEGORY_ROUTE_PROVIDER,
        VISA_SERVICES_VISA_TYPE_ROUTE_PROVIDER,
        VISA_SERVICES_VISA_DISCOUNT_CATEGORY_ROUTE_PROVIDER,
      ],
    };
  }
}
