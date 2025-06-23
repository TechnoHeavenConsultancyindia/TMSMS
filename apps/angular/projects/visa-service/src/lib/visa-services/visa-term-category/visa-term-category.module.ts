import { NgModule } from '@angular/core';
import { VisaTermCategoryComponent } from './components/visa-term-category.component';
import { VisaTermCategoryRoutingModule } from './visa-term-category-routing.module';

@NgModule({
  declarations: [],
  imports: [VisaTermCategoryComponent, VisaTermCategoryRoutingModule],
})
export class VisaTermCategoryModule {}

export function loadVisaTermCategoryModuleAsChild() {
  return Promise.resolve(VisaTermCategoryModule);
}
