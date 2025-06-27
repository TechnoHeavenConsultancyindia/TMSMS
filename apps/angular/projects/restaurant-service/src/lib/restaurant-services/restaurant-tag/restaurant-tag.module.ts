import { NgModule } from '@angular/core';
import { RestaurantTagComponent } from './components/restaurant-tag.component';
import { RestaurantTagRoutingModule } from './restaurant-tag-routing.module';

@NgModule({
  declarations: [],
  imports: [RestaurantTagComponent, RestaurantTagRoutingModule],
})
export class RestaurantTagModule {}

export function loadRestaurantTagModuleAsChild() {
  return Promise.resolve(RestaurantTagModule);
}
