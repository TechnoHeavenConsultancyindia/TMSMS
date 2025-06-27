import { NgModule } from '@angular/core';
import { AgentPermissionTypeComponent } from './components/agent-permission-type.component';
import { AgentPermissionTypeRoutingModule } from './agent-permission-type-routing.module';

@NgModule({
  declarations: [],
  imports: [AgentPermissionTypeComponent, AgentPermissionTypeRoutingModule],
})
export class AgentPermissionTypeModule {}

export function loadAgentPermissionTypeModuleAsChild() {
  return Promise.resolve(AgentPermissionTypeModule);
}
