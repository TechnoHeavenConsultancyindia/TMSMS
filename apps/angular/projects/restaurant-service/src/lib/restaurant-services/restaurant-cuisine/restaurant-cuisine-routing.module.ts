import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantCuisineComponent } from './components/restaurant-cuisine.component';

export const routes: Routes = [
  {
    path: '',
    component: RestaurantCuisineComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantCuisineRoutingModule {}
