import { ModuleWithProviders, NgModule } from '@angular/core';
import { COMMON_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';
import { COMMON_SERVICES_COUNTRY_ROUTE_PROVIDER } from './providers/country-route.provider';
import { COMMON_SERVICES_CITY_ROUTE_PROVIDER } from './providers/city-route.provider';
import { COMMON_SERVICES_PROVINCE_ROUTE_PROVIDER } from './providers/province-route.provider';
import { COMMON_SERVICES_REGION_ROUTE_PROVIDER } from './providers/region-route.provider';
import { COMMON_SERVICES_WEEK_DAY_ROUTE_PROVIDER } from './providers/week-day-route.provider';
import { COMMON_SERVICES_PROMO_CODE_MASTER_ROUTE_PROVIDER } from './providers/promo-code-master-route.provider';
import { COMMON_SERVICES_PROMO_CODE_USAGE_TRACKING_ROUTE_PROVIDER } from './providers/promo-code-usage-tracking-route.provider';
import { COMMON_SERVICES_SUPPLIER_SERVICE_TYPE_ROUTE_PROVIDER } from './providers/supplier-service-type-route.provider';

@NgModule()
export class CommonServiceConfigModule {
  static forRoot(): ModuleWithProviders<CommonServiceConfigModule> {
    return {
      ngModule: CommonServiceConfigModule,
      providers: [
        COMMON_SERVICE_ROUTE_PROVIDERS,
        COMMON_SERVICES_COUNTRY_ROUTE_PROVIDER,
        COMMON_SERVICES_CITY_ROUTE_PROVIDER,
        COMMON_SERVICES_PROVINCE_ROUTE_PROVIDER,
        COMMON_SERVICES_REGION_ROUTE_PROVIDER,
        COMMON_SERVICES_WEEK_DAY_ROUTE_PROVIDER,
        COMMON_SERVICES_PROMO_CODE_MASTER_ROUTE_PROVIDER,
        COMMON_SERVICES_PROMO_CODE_USAGE_TRACKING_ROUTE_PROVIDER,
        COMMON_SERVICES_SUPPLIER_SERVICE_TYPE_ROUTE_PROVIDER,
      ],
    };
  }
}
