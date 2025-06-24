import { NgModule } from '@angular/core';
import { RegionComponent } from './components/region.component';
import { RegionRoutingModule } from './region-routing.module';

@NgModule({
  declarations: [],
  imports: [RegionComponent, RegionRoutingModule],
})
export class RegionModule {}

export function loadRegionModuleAsChild() {
  return Promise.resolve(RegionModule);
}
