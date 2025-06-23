import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VisaTermCategoryComponent } from './components/visa-term-category.component';

export const routes: Routes = [
  {
    path: '',
    component: VisaTermCategoryComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VisaTermCategoryRoutingModule {}
