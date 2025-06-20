import { NgModule } from '@angular/core';
import { TransferTypeComponent } from './components/transfer-type.component';
import { TransferTypeRoutingModule } from './transfer-type-routing.module';

@NgModule({
  declarations: [],
  imports: [TransferTypeComponent, TransferTypeRoutingModule],
})
export class TransferTypeModule {}

export function loadTransferTypeModuleAsChild() {
  return Promise.resolve(TransferTypeModule);
}
