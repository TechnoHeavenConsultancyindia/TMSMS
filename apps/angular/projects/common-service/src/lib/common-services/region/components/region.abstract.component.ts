import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { RegionDto } from '../../../proxy/common-service/common-services/models';
import { RegionViewService } from '../services/region.service';
import { RegionDetailViewService } from '../services/region-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractRegionComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(RegionViewService);
  public readonly serviceDetail = inject(RegionDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::Regions';
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

  update(record: RegionDto) {
    this.serviceDetail.update(record);
  }

  delete(record: RegionDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }

  checkActionButtonVisibility() {
    if (this.isActionButtonVisible !== null) {
      return;
    }

    const canEdit = this.permissionService.getGrantedPolicy('CommonService.Regions.Edit');
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.Regions.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
