import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentVoucherTypeComponent } from './components/agent-voucher-type.component';

export const routes: Routes = [
  {
    path: '',
    component: AgentVoucherTypeComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentVoucherTypeRoutingModule {}
