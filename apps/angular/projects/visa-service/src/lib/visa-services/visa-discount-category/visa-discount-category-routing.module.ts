import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VisaDiscountCategoryComponent } from './components/visa-discount-category.component';

export const routes: Routes = [
  {
    path: '',
    component: VisaDiscountCategoryComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VisaDiscountCategoryRoutingModule {}
