import { NgModule } from '@angular/core';
import { VisaTypeComponent } from './components/visa-type.component';
import { VisaTypeRoutingModule } from './visa-type-routing.module';

@NgModule({
  declarations: [],
  imports: [VisaTypeComponent, VisaTypeRoutingModule],
})
export class VisaTypeModule {}

export function loadVisaTypeModuleAsChild() {
  return Promise.resolve(VisaTypeModule);
}
