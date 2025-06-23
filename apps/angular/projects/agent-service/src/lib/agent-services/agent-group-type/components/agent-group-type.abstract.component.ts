import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { AgentGroupTypeDto } from '../../../proxy/agent-service/agent-services/models';
import { AgentGroupTypeViewService } from '../services/agent-group-type.service';
import { AgentGroupTypeDetailViewService } from '../services/agent-group-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractAgentGroupTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(AgentGroupTypeViewService);
  public readonly serviceDetail = inject(AgentGroupTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'AgentService::AgentGroupTypes';
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

  update(record: AgentGroupTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: AgentGroupTypeDto) {
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
      'AgentService.AgentGroupTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'AgentService.AgentGroupTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
