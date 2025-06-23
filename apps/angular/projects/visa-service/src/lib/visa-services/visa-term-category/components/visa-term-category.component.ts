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
import { VisaTermCategoryViewService } from '../services/visa-term-category.service';
import { VisaTermCategoryDetailViewService } from '../services/visa-term-category-detail.service';
import { VisaTermCategoryDetailModalComponent } from './visa-term-category-detail.component';
import {
  AbstractVisaTermCategoryComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './visa-term-category.abstract.component';

@Component({
  selector: 'lib-visa-term-category',
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
    VisaTermCategoryDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    VisaTermCategoryViewService,
    VisaTermCategoryDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './visa-term-category.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class VisaTermCategoryComponent extends AbstractVisaTermCategoryComponent {}
