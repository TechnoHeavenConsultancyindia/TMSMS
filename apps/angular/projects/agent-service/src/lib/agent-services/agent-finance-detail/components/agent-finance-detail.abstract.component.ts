import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { AgentFinanceDetailDto } from '../../../proxy/agent-service/agent-services/models';
import { AgentFinanceDetailViewService } from '../services/agent-finance-detail.service';
import { AgentFinanceDetailDetailViewService } from '../services/agent-finance-detail-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractAgentFinanceDetailComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(AgentFinanceDetailViewService);
  public readonly serviceDetail = inject(AgentFinanceDetailDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'AgentService::AgentFinanceDetails';
  protected isActionButtonVisible: boolean | null = null;

  ngOnInit() {
    this.service.hookToQuery();
    this.checkActionButtonVisibility();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: AgentFinanceDetailDto) {
    this.serviceDetail.update(record);
  }

  delete(record: AgentFinanceDetailDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }

  checkActionButtonVisibility() {
    if (this.isActionButtonVisible !== null) {
      return;
    }

    const canEdit = this.permissionService.getGrantedPolicy(
      'AgentService.AgentFinanceDetails.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'AgentService.AgentFinanceDetails.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
