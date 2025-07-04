import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadCountryModuleAsChild } from './common-services/country/country.module';
import { loadCityModuleAsChild } from './common-services/city/city.module';
import { loadProvinceModuleAsChild } from './common-services/province/province.module';
import { loadRegionModuleAsChild } from './common-services/region/region.module';
import { loadWeekDayModuleAsChild } from './common-services/week-day/week-day.module';
import { loadPromoCodeMasterModuleAsChild } from './common-services/promo-code-master/promo-code-master.module';
import { loadPromoCodeUsageTrackingModuleAsChild } from './common-services/promo-code-usage-tracking/promo-code-usage-tracking.module';
import { loadServiceTypeModuleAsChild } from './common-services/service-type/service-type.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  { path: 'countries', loadChildren: loadCountryModuleAsChild },
  { path: 'cities', loadChildren: loadCityModuleAsChild },
  { path: 'provinces', loadChildren: loadProvinceModuleAsChild },
  { path: 'regions', loadChildren: loadRegionModuleAsChild },
  { path: 'week-days', loadChildren: loadWeekDayModuleAsChild },
  { path: 'promo-code-masters', loadChildren: loadPromoCodeMasterModuleAsChild },
  {
    path: 'promo-code-usage-trackings',
    loadChildren: loadPromoCodeUsageTrackingModuleAsChild,
  },
  { path: 'service-types', loadChildren: loadServiceTypeModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CommonServiceRoutingModule {}
