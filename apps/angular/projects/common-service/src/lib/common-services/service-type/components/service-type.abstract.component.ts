import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { ServiceTypeDto } from '../../../proxy/common-service/common-services/models';
import { ServiceTypeViewService } from '../services/service-type.service';
import { ServiceTypeDetailViewService } from '../services/service-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractServiceTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ServiceTypeViewService);
  public readonly serviceDetail = inject(ServiceTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::ServiceTypes';
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

  update(record: ServiceTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ServiceTypeDto) {
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
      'CommonService.ServiceTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.ServiceTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
