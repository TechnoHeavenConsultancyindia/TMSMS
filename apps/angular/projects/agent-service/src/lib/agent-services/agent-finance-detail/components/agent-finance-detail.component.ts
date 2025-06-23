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
import { AgentFinanceDetailViewService } from '../services/agent-finance-detail.service';
import { AgentFinanceDetailDetailViewService } from '../services/agent-finance-detail-detail.service';
import { AgentFinanceDetailDetailModalComponent } from './agent-finance-detail-detail.component';
import {
  AbstractAgentFinanceDetailComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './agent-finance-detail.abstract.component';

@Component({
  selector: 'lib-agent-finance-detail',
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
    AgentFinanceDetailDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    AgentFinanceDetailViewService,
    AgentFinanceDetailDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './agent-finance-detail.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class AgentFinanceDetailComponent extends AbstractAgentFinanceDetailComponent {}
