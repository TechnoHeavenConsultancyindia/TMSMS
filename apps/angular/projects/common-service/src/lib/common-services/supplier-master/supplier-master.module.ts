import { NgModule } from '@angular/core';
import { SupplierMasterComponent } from './components/supplier-master.component';
import { SupplierMasterRoutingModule } from './supplier-master-routing.module';

@NgModule({
  declarations: [],
  imports: [SupplierMasterComponent, SupplierMasterRoutingModule],
})
export class SupplierMasterModule {}

export function loadSupplierMasterModuleAsChild() {
  return Promise.resolve(SupplierMasterModule);
}
