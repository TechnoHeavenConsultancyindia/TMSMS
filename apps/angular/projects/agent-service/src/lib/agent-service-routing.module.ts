import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadAgentGroupTypeModuleAsChild } from './agent-services/agent-group-type/agent-group-type.module';
import { loadAgentPermissionTypeModuleAsChild } from './agent-services/agent-permission-type/agent-permission-type.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  { path: 'agent-group-types', loadChildren: loadAgentGroupTypeModuleAsChild },
  { path: 'agent-permission-types', loadChildren: loadAgentPermissionTypeModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentServiceRoutingModule {}
