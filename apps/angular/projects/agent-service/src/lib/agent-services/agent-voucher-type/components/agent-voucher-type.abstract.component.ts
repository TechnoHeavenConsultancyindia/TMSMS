import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { AgentVoucherTypeDto } from '../../../proxy/agent-service/agent-services/models';
import { AgentVoucherTypeViewService } from '../services/agent-voucher-type.service';
import { AgentVoucherTypeDetailViewService } from '../services/agent-voucher-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractAgentVoucherTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(AgentVoucherTypeViewService);
  public readonly serviceDetail = inject(AgentVoucherTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'AgentService::AgentVoucherTypes';
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

  update(record: AgentVoucherTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: AgentVoucherTypeDto) {
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
      'AgentService.AgentVoucherTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'AgentService.AgentVoucherTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
