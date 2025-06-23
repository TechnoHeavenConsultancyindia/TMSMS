import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadAgentGroupTypeModuleAsChild } from './agent-services/agent-group-type/agent-group-type.module';
import { loadAgentPermissionTypeModuleAsChild } from './agent-services/agent-permission-type/agent-permission-type.module';
import { loadAgentVoucherTypeModuleAsChild } from './agent-services/agent-voucher-type/agent-voucher-type.module';
import { loadAgentFinanceDetailModuleAsChild } from './agent-services/agent-finance-detail/agent-finance-detail.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  { path: 'agent-group-types', loadChildren: loadAgentGroupTypeModuleAsChild },
  { path: 'agent-permission-types', loadChildren: loadAgentPermissionTypeModuleAsChild },
  { path: 'agent-voucher-types', loadChildren: loadAgentVoucherTypeModuleAsChild },
  { path: 'agent-finance-details', loadChildren: loadAgentFinanceDetailModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentServiceRoutingModule {}
