import { NgModule } from '@angular/core';
import { PromoCodeUsageTrackingComponent } from './components/promo-code-usage-tracking.component';
import { PromoCodeUsageTrackingRoutingModule } from './promo-code-usage-tracking-routing.module';

@NgModule({
  declarations: [],
  imports: [PromoCodeUsageTrackingComponent, PromoCodeUsageTrackingRoutingModule],
})
export class PromoCodeUsageTrackingModule {}

export function loadPromoCodeUsageTrackingModuleAsChild() {
  return Promise.resolve(PromoCodeUsageTrackingModule);
}
