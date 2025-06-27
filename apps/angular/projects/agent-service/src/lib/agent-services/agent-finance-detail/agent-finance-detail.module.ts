import { NgModule } from '@angular/core';
import { AgentFinanceDetailComponent } from './components/agent-finance-detail.component';
import { AgentFinanceDetailRoutingModule } from './agent-finance-detail-routing.module';

@NgModule({
  declarations: [],
  imports: [AgentFinanceDetailComponent, AgentFinanceDetailRoutingModule],
})
export class AgentFinanceDetailModule {}

export function loadAgentFinanceDetailModuleAsChild() {
  return Promise.resolve(AgentFinanceDetailModule);
}
