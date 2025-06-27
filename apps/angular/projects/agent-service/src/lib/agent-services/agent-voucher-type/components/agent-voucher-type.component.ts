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
import { AgentVoucherTypeViewService } from '../services/agent-voucher-type.service';
import { AgentVoucherTypeDetailViewService } from '../services/agent-voucher-type-detail.service';
import { AgentVoucherTypeDetailModalComponent } from './agent-voucher-type-detail.component';
import {
  AbstractAgentVoucherTypeComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './agent-voucher-type.abstract.component';

@Component({
  selector: 'lib-agent-voucher-type',
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
    AgentVoucherTypeDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    AgentVoucherTypeViewService,
    AgentVoucherTypeDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './agent-voucher-type.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class AgentVoucherTypeComponent extends AbstractAgentVoucherTypeComponent {}
