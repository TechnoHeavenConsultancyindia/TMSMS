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
import { TransferTypeViewService } from '../services/transfer-type.service';
import { TransferTypeDetailViewService } from '../services/transfer-type-detail.service';
import { TransferTypeDetailModalComponent } from './transfer-type-detail.component';
import {
  AbstractTransferTypeComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './transfer-type.abstract.component';

@Component({
  selector: 'lib-transfer-type',
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
    TransferTypeDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    TransferTypeViewService,
    TransferTypeDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './transfer-type.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class TransferTypeComponent extends AbstractTransferTypeComponent {}
