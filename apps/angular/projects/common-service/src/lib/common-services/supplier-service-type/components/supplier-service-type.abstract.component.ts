import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { SupplierServiceTypeDto } from '../../../proxy/common-service/common-services/models';
import { SupplierServiceTypeViewService } from '../services/supplier-service-type.service';
import { SupplierServiceTypeDetailViewService } from '../services/supplier-service-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractSupplierServiceTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(SupplierServiceTypeViewService);
  public readonly serviceDetail = inject(SupplierServiceTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::SupplierServiceTypes';
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

  update(record: SupplierServiceTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: SupplierServiceTypeDto) {
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
      'CommonService.SupplierServiceTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.SupplierServiceTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
