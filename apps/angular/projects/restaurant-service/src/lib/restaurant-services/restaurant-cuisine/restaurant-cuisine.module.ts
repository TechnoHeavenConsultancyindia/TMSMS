import { NgModule } from '@angular/core';
import { RestaurantCuisineComponent } from './components/restaurant-cuisine.component';
import { RestaurantCuisineRoutingModule } from './restaurant-cuisine-routing.module';

@NgModule({
  declarations: [],
  imports: [RestaurantCuisineComponent, RestaurantCuisineRoutingModule],
})
export class RestaurantCuisineModule {}

export function loadRestaurantCuisineModuleAsChild() {
  return Promise.resolve(RestaurantCuisineModule);
}
