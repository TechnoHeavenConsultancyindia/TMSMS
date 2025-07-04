import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PromoCodeMasterComponent } from './components/promo-code-master.component';

export const routes: Routes = [
  {
    path: '',
    component: PromoCodeMasterComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PromoCodeMasterRoutingModule {}
