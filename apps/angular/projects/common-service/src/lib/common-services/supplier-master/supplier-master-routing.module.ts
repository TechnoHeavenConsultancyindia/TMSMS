import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SupplierMasterComponent } from './components/supplier-master.component';

export const routes: Routes = [
  {
    path: '',
    component: SupplierMasterComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SupplierMasterRoutingModule {}
