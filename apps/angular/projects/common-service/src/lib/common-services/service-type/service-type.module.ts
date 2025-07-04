import { NgModule } from '@angular/core';
import { ServiceTypeComponent } from './components/service-type.component';
import { ServiceTypeRoutingModule } from './service-type-routing.module';

@NgModule({
  declarations: [],
  imports: [ServiceTypeComponent, ServiceTypeRoutingModule],
})
export class ServiceTypeModule {}

export function loadServiceTypeModuleAsChild() {
  return Promise.resolve(ServiceTypeModule);
}
