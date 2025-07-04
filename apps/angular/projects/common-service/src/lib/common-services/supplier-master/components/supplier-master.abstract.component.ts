import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { SupplierMasterWithNavigationPropertiesDto } from '../../../proxy/common-service/common-services/models';
import { SupplierMasterViewService } from '../services/supplier-master.service';
import { SupplierMasterDetailViewService } from '../services/supplier-master-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractSupplierMasterComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(SupplierMasterViewService);
  public readonly serviceDetail = inject(SupplierMasterDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::SupplierMasters';
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

  update(record: SupplierMasterWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: SupplierMasterWithNavigationPropertiesDto) {
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
      'CommonService.SupplierMasters.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.SupplierMasters.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
