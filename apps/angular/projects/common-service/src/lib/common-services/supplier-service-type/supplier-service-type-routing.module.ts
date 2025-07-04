import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SupplierServiceTypeComponent } from './components/supplier-service-type.component';

export const routes: Routes = [
  {
    path: '',
    component: SupplierServiceTypeComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SupplierServiceTypeRoutingModule {}
