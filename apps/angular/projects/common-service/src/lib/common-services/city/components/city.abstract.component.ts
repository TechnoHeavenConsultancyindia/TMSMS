import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { CityDto } from '../../../proxy/common-service/common-services/models';
import { CityViewService } from '../services/city.service';
import { CityDetailViewService } from '../services/city-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractCityComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(CityViewService);
  public readonly serviceDetail = inject(CityDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::City';
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

  update(record: CityDto) {
    this.serviceDetail.update(record);
  }

  delete(record: CityDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }

  checkActionButtonVisibility() {
    if (this.isActionButtonVisible !== null) {
      return;
    }

    const canEdit = this.permissionService.getGrantedPolicy('CommonService.Cities.Edit');
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.Cities.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
