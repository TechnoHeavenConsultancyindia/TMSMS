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
import { SupplierServiceTypeViewService } from '../services/supplier-service-type.service';
import { SupplierServiceTypeDetailViewService } from '../services/supplier-service-type-detail.service';
import { SupplierServiceTypeDetailModalComponent } from './supplier-service-type-detail.component';
import {
  AbstractSupplierServiceTypeComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './supplier-service-type.abstract.component';

@Component({
  selector: 'lib-supplier-service-type',
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
    SupplierServiceTypeDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    SupplierServiceTypeViewService,
    SupplierServiceTypeDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './supplier-service-type.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class SupplierServiceTypeComponent extends AbstractSupplierServiceTypeComponent {}
