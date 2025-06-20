import { ModuleWithProviders, NgModule } from '@angular/core';
import { TOUR_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class TourServiceConfigModule {
  static forRoot(): ModuleWithProviders<TourServiceConfigModule> {
    return {
      ngModule: TourServiceConfigModule,
      providers: [TOUR_SERVICE_ROUTE_PROVIDERS],
    };
  }
}
