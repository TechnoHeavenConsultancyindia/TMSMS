import { NgModule } from '@angular/core';
import { AgentVoucherTypeComponent } from './components/agent-voucher-type.component';
import { AgentVoucherTypeRoutingModule } from './agent-voucher-type-routing.module';

@NgModule({
  declarations: [],
  imports: [AgentVoucherTypeComponent, AgentVoucherTypeRoutingModule],
})
export class AgentVoucherTypeModule {}

export function loadAgentVoucherTypeModuleAsChild() {
  return Promise.resolve(AgentVoucherTypeModule);
}
