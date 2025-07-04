import { NgModule } from '@angular/core';
import { SupplierServiceTypeComponent } from './components/supplier-service-type.component';
import { SupplierServiceTypeRoutingModule } from './supplier-service-type-routing.module';

@NgModule({
  declarations: [],
  imports: [SupplierServiceTypeComponent, SupplierServiceTypeRoutingModule],
})
export class SupplierServiceTypeModule {}

export function loadSupplierServiceTypeModuleAsChild() {
  return Promise.resolve(SupplierServiceTypeModule);
}
