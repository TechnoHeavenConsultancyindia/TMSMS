import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantDietaryTypeComponent } from './components/restaurant-dietary-type.component';

export const routes: Routes = [
  {
    path: '',
    component: RestaurantDietaryTypeComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantDietaryTypeRoutingModule {}
