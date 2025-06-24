import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { RestaurantCuisineDto } from '../../../proxy/restaurant-service/restaurant-services/models';
import { RestaurantCuisineViewService } from '../services/restaurant-cuisine.service';
import { RestaurantCuisineDetailViewService } from '../services/restaurant-cuisine-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractRestaurantCuisineComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(RestaurantCuisineViewService);
  public readonly serviceDetail = inject(RestaurantCuisineDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'RestaurantService::RestaurantCuisine';
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

  update(record: RestaurantCuisineDto) {
    this.serviceDetail.update(record);
  }

  delete(record: RestaurantCuisineDto) {
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
      'RestaurantService.RestaurantCuisines.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'RestaurantService.RestaurantCuisines.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
