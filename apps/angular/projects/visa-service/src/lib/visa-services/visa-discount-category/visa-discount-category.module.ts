import { NgModule } from '@angular/core';
import { VisaDiscountCategoryComponent } from './components/visa-discount-category.component';
import { VisaDiscountCategoryRoutingModule } from './visa-discount-category-routing.module';

@NgModule({
  declarations: [],
  imports: [VisaDiscountCategoryComponent, VisaDiscountCategoryRoutingModule],
})
export class VisaDiscountCategoryModule {}

export function loadVisaDiscountCategoryModuleAsChild() {
  return Promise.resolve(VisaDiscountCategoryModule);
}
