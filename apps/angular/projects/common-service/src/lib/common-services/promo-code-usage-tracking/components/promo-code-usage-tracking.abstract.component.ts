import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { PromoCodeUsageTrackingWithNavigationPropertiesDto } from '../../../proxy/common-service/common-services/models';
import { PromoCodeUsageTrackingViewService } from '../services/promo-code-usage-tracking.service';
import { PromoCodeUsageTrackingDetailViewService } from '../services/promo-code-usage-tracking-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractPromoCodeUsageTrackingComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(PromoCodeUsageTrackingViewService);
  public readonly serviceDetail = inject(PromoCodeUsageTrackingDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::PromoCodeUsageTrackings';
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

  update(record: PromoCodeUsageTrackingWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: PromoCodeUsageTrackingWithNavigationPropertiesDto) {
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
      'CommonService.PromoCodeUsageTrackings.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.PromoCodeUsageTrackings.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
