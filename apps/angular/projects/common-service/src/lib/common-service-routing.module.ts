import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadCountryModuleAsChild } from './common-services/country/country.module';
import { loadCityModuleAsChild } from './common-services/city/city.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  { path: 'countries', loadChildren: loadCountryModuleAsChild },
  { path: 'cities', loadChildren: loadCityModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CommonServiceRoutingModule {}
