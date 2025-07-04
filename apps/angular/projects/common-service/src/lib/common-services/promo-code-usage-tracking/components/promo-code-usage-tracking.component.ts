import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PromoCodeUsageTrackingViewService } from '../services/promo-code-usage-tracking.service';
import { PromoCodeUsageTrackingDetailViewService } from '../services/promo-code-usage-tracking-detail.service';
import { PromoCodeUsageTrackingDetailModalComponent } from './promo-code-usage-tracking-detail.component';
import {
  AbstractPromoCodeUsageTrackingComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './promo-code-usage-tracking.abstract.component';

@Component({
  selector: 'lib-promo-code-usage-tracking',
  changeDetection: ChangeDetectionStrategy.Default,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    PromoCodeUsageTrackingDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    PromoCodeUsageTrackingViewService,
    PromoCodeUsageTrackingDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './promo-code-usage-tracking.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class PromoCodeUsageTrackingComponent extends AbstractPromoCodeUsageTrackingComponent {}
