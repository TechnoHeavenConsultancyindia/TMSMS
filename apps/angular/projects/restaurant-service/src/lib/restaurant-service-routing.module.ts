import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  {
    path: 'restaurant-types',
    loadChildren: () =>
      import('./restaurant-services/restaurant-type/restaurant-type.module').then(
        m => m.RestaurantTypeModule,
      ),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantServiceRoutingModule {}
