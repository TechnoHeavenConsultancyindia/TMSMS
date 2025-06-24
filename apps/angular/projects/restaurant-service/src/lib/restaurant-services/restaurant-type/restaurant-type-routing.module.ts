import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantTypeComponent } from './components/restaurant-type.component';

export const routes: Routes = [
  {
    path: '',
    component: RestaurantTypeComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantTypeRoutingModule {}
