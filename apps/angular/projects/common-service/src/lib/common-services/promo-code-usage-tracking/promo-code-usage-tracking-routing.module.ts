import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PromoCodeUsageTrackingComponent } from './components/promo-code-usage-tracking.component';

export const routes: Routes = [
  {
    path: '',
    component: PromoCodeUsageTrackingComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PromoCodeUsageTrackingRoutingModule {}
