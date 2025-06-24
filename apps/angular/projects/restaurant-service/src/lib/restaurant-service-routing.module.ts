import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadRestaurantTagModuleAsChild } from './restaurant-services/restaurant-tag/restaurant-tag.module';
import { loadRestaurantTypeModuleAsChild } from './restaurant-services/restaurant-type/restaurant-type.module';
import { loadRestaurantDietaryTypeModuleAsChild } from './restaurant-services/restaurant-dietary-type/restaurant-dietary-type.module';
import { loadRestaurantCuisineModuleAsChild } from './restaurant-services/restaurant-cuisine/restaurant-cuisine.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  { path: 'restaurant-types', loadChildren: loadRestaurantTypeModuleAsChild },
  { path: 'restaurant-tags', loadChildren: loadRestaurantTagModuleAsChild },
  {
    path: 'restaurant-dietary-types',
    loadChildren: loadRestaurantDietaryTypeModuleAsChild,
  },
  { path: 'restaurant-cuisines', loadChildren: loadRestaurantCuisineModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantServiceRoutingModule {}
