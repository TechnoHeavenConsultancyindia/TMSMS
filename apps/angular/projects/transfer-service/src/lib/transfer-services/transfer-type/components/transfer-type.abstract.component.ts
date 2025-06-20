import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { TransferTypeDto } from '../../../proxy/transfer-service/transfer-services/models';
import { TransferTypeViewService } from '../services/transfer-type.service';
import { TransferTypeDetailViewService } from '../services/transfer-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractTransferTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(TransferTypeViewService);
  public readonly serviceDetail = inject(TransferTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'TransferService::TransferTypes';
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

  update(record: TransferTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: TransferTypeDto) {
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
      'TransferService.TransferTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'TransferService.TransferTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
