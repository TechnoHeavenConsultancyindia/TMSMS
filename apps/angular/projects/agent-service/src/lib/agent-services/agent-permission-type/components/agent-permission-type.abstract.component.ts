import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { AgentPermissionTypeDto } from '../../../proxy/agent-service/agent-services/models';
import { AgentPermissionTypeViewService } from '../services/agent-permission-type.service';
import { AgentPermissionTypeDetailViewService } from '../services/agent-permission-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractAgentPermissionTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(AgentPermissionTypeViewService);
  public readonly serviceDetail = inject(AgentPermissionTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'AgentService::AgentPermissionTypes';
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

  update(record: AgentPermissionTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: AgentPermissionTypeDto) {
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
      'AgentService.AgentPermissionTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'AgentService.AgentPermissionTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
