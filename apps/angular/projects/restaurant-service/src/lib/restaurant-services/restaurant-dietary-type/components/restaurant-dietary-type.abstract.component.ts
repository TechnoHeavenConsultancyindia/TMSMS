import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { RestaurantDietaryTypeDto } from '../../../proxy/restaurant-service/restaurant-services/models';
import { RestaurantDietaryTypeViewService } from '../services/restaurant-dietary-type.service';
import { RestaurantDietaryTypeDetailViewService } from '../services/restaurant-dietary-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractRestaurantDietaryTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(RestaurantDietaryTypeViewService);
  public readonly serviceDetail = inject(RestaurantDietaryTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'RestaurantService::RestaurantDietaryType';
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

  update(record: RestaurantDietaryTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: RestaurantDietaryTypeDto) {
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
      'RestaurantService.RestaurantDietaryTypes.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'RestaurantService.RestaurantDietaryTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
