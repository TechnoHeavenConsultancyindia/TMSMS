import { NgModule } from '@angular/core';
import { ProvinceComponent } from './components/province.component';
import { ProvinceRoutingModule } from './province-routing.module';

@NgModule({
  declarations: [],
  imports: [ProvinceComponent, ProvinceRoutingModule],
})
export class ProvinceModule {}

export function loadProvinceModuleAsChild() {
  return Promise.resolve(ProvinceModule);
}
