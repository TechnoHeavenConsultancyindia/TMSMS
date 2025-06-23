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
import { VisaDiscountCategoryViewService } from '../services/visa-discount-category.service';
import { VisaDiscountCategoryDetailViewService } from '../services/visa-discount-category-detail.service';
import { VisaDiscountCategoryDetailModalComponent } from './visa-discount-category-detail.component';
import {
  AbstractVisaDiscountCategoryComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './visa-discount-category.abstract.component';

@Component({
  selector: 'lib-visa-discount-category',
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
    VisaDiscountCategoryDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    VisaDiscountCategoryViewService,
    VisaDiscountCategoryDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './visa-discount-category.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class VisaDiscountCategoryComponent extends AbstractVisaDiscountCategoryComponent {}
