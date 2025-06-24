import { NgModule } from '@angular/core';
import { RestaurantTypeComponent } from './components/restaurant-type.component';
import { RestaurantTypeRoutingModule } from './restaurant-type-routing.module';

@NgModule({
  declarations: [],
  imports: [RestaurantTypeComponent, RestaurantTypeRoutingModule],
})
export class RestaurantTypeModule {}

export function loadRestaurantTypeModuleAsChild() {
  return Promise.resolve(RestaurantTypeModule);
}
