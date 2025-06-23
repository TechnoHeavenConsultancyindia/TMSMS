import { NgModule } from '@angular/core';
import { RestaurantDietaryTypeComponent } from './components/restaurant-dietary-type.component';
import { RestaurantDietaryTypeRoutingModule } from './restaurant-dietary-type-routing.module';

@NgModule({
  declarations: [],
  imports: [RestaurantDietaryTypeComponent, RestaurantDietaryTypeRoutingModule],
})
export class RestaurantDietaryTypeModule {}

export function loadRestaurantDietaryTypeModuleAsChild() {
  return Promise.resolve(RestaurantDietaryTypeModule);
}
