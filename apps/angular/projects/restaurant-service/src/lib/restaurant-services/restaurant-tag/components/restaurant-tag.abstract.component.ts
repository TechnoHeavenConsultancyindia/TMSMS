import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { RestaurantTagDto } from '../../../proxy/restaurant-service/restaurant-services/models';
import { RestaurantTagViewService } from '../services/restaurant-tag.service';
import { RestaurantTagDetailViewService } from '../services/restaurant-tag-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractRestaurantTagComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(RestaurantTagViewService);
  public readonly serviceDetail = inject(RestaurantTagDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'RestaurantService::RestaurantTag';
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

  update(record: RestaurantTagDto) {
    this.serviceDetail.update(record);
  }

  delete(record: RestaurantTagDto) {
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
      'RestaurantService.RestaurantTags.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'RestaurantService.RestaurantTags.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
