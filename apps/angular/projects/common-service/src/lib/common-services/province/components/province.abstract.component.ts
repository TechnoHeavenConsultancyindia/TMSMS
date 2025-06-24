import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { ProvinceDto } from '../../../proxy/common-service/common-services/models';
import { ProvinceViewService } from '../services/province.service';
import { ProvinceDetailViewService } from '../services/province-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractProvinceComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ProvinceViewService);
  public readonly serviceDetail = inject(ProvinceDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::Provinces';
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

  update(record: ProvinceDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ProvinceDto) {
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
      'CommonService.Provinces.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.Provinces.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
