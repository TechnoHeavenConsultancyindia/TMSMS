import { NgModule } from '@angular/core';
import { AgentGroupTypeComponent } from './components/agent-group-type.component';
import { AgentGroupTypeRoutingModule } from './agent-group-type-routing.module';

@NgModule({
  declarations: [],
  imports: [AgentGroupTypeComponent, AgentGroupTypeRoutingModule],
})
export class AgentGroupTypeModule {}

export function loadAgentGroupTypeModuleAsChild() {
  return Promise.resolve(AgentGroupTypeModule);
}
