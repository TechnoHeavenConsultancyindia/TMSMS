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
import { PromoCodeMasterViewService } from '../services/promo-code-master.service';
import { PromoCodeMasterDetailViewService } from '../services/promo-code-master-detail.service';
import { PromoCodeMasterDetailModalComponent } from './promo-code-master-detail.component';
import {
  AbstractPromoCodeMasterComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './promo-code-master.abstract.component';

@Component({
  selector: 'lib-promo-code-master',
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
    PromoCodeMasterDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    PromoCodeMasterViewService,
    PromoCodeMasterDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './promo-code-master.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class PromoCodeMasterComponent extends AbstractPromoCodeMasterComponent {}
