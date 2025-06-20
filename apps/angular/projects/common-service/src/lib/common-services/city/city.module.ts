import { NgModule } from '@angular/core';
import { CityComponent } from './components/city.component';
import { CityRoutingModule } from './city-routing.module';

@NgModule({
  declarations: [],
  imports: [CityComponent, CityRoutingModule],
})
export class CityModule {}

export function loadCityModuleAsChild() {
  return Promise.resolve(CityModule);
}
