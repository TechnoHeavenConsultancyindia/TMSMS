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
import { SupplierMasterViewService } from '../services/supplier-master.service';
import { SupplierMasterDetailViewService } from '../services/supplier-master-detail.service';
import { SupplierMasterDetailModalComponent } from './supplier-master-detail.component';
import {
  AbstractSupplierMasterComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './supplier-master.abstract.component';

@Component({
  selector: 'lib-supplier-master',
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
    SupplierMasterDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    SupplierMasterViewService,
    SupplierMasterDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './supplier-master.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class SupplierMasterComponent extends AbstractSupplierMasterComponent {}
