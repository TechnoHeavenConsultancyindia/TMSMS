import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadCountryModuleAsChild } from './common-services/country/country.module';
import { loadCityModuleAsChild } from './common-services/city/city.module';
import { loadProvinceModuleAsChild } from './common-services/province/province.module';
import { loadRegionModuleAsChild } from './common-services/region/region.module';

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
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CommonServiceRoutingModule {}
