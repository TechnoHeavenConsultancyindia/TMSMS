import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentFinanceDetailComponent } from './components/agent-finance-detail.component';

export const routes: Routes = [
  {
    path: '',
    component: AgentFinanceDetailComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentFinanceDetailRoutingModule {}
