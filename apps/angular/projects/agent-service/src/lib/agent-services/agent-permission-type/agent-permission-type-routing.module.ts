import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentPermissionTypeComponent } from './components/agent-permission-type.component';

export const routes: Routes = [
  {
    path: '',
    component: AgentPermissionTypeComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentPermissionTypeRoutingModule {}
