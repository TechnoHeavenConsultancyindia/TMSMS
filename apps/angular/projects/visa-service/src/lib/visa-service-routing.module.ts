import { NgModule } from '@angular/core';
import { RouterOutletComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { loadVisaTermCategoryModuleAsChild } from './visa-services/visa-term-category/visa-term-category.module';
import { loadVisaTypeModuleAsChild } from './visa-services/visa-type/visa-type.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [],
  },
  { path: 'visa-term-categories', loadChildren: loadVisaTermCategoryModuleAsChild },
  { path: 'visa-types', loadChildren: loadVisaTypeModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VisaServiceRoutingModule {}
