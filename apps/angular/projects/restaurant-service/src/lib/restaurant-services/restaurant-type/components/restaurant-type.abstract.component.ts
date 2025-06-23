import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { RestaurantTypeDto } from '../../../proxy/restaurant-services/models';
import { RestaurantTypeViewService } from '../services/restaurant-type.service';
import { RestaurantTypeDetailViewService } from '../services/restaurant-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractRestaurantTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(RestaurantTypeViewService);
  public readonly serviceDetail = inject(RestaurantTypeDetailViewService);
  protected title = 'RestaurantService::RestaurantType';

  ngOnInit() {
    this.service.hookToQuery();
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
}
