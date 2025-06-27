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
import { AgentPermissionTypeViewService } from '../services/agent-permission-type.service';
import { AgentPermissionTypeDetailViewService } from '../services/agent-permission-type-detail.service';
import { AgentPermissionTypeDetailModalComponent } from './agent-permission-type-detail.component';
import {
  AbstractAgentPermissionTypeComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './agent-permission-type.abstract.component';

@Component({
  selector: 'lib-agent-permission-type',
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
    AgentPermissionTypeDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    AgentPermissionTypeViewService,
    AgentPermissionTypeDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './agent-permission-type.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class AgentPermissionTypeComponent extends AbstractAgentPermissionTypeComponent {}
