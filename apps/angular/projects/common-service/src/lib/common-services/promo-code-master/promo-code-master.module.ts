import { NgModule } from '@angular/core';
import { PromoCodeMasterComponent } from './components/promo-code-master.component';
import { PromoCodeMasterRoutingModule } from './promo-code-master-routing.module';

@NgModule({
  declarations: [],
  imports: [PromoCodeMasterComponent, PromoCodeMasterRoutingModule],
})
export class PromoCodeMasterModule {}

export function loadPromoCodeMasterModuleAsChild() {
  return Promise.resolve(PromoCodeMasterModule);
}
