import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { RestaurantTypeDto } from '../../../proxy/restaurant-service/restaurant-services/models';
import { RestaurantTypeViewService } from '../services/restaurant-type.service';
import { RestaurantTypeDetailViewService } from '../services/restaurant-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractRestaurantTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(RestaurantTypeViewService);
  public readonly serviceDetail = inject(RestaurantTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'RestaurantService::RestaurantType';
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

  update(record: RestaurantTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: RestaurantTypeDto) {
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
      'RestaurantService.RestaurantTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'RestaurantService.RestaurantTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
