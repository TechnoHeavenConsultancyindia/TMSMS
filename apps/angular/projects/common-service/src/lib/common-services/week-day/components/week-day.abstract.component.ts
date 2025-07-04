import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { WeekDayDto } from '../../../proxy/common-service/common-services/models';
import { WeekDayViewService } from '../services/week-day.service';
import { WeekDayDetailViewService } from '../services/week-day-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractWeekDayComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(WeekDayViewService);
  public readonly serviceDetail = inject(WeekDayDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::WeekDays';
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

  update(record: WeekDayDto) {
    this.serviceDetail.update(record);
  }

  delete(record: WeekDayDto) {
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
      'CommonService.WeekDays.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.WeekDays.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
