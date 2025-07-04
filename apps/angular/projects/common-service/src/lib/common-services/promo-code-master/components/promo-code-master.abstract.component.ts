import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { PromoCodeMasterWithNavigationPropertiesDto } from '../../../proxy/common-service/common-services/models';
import { PromoCodeMasterViewService } from '../services/promo-code-master.service';
import { PromoCodeMasterDetailViewService } from '../services/promo-code-master-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractPromoCodeMasterComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(PromoCodeMasterViewService);
  public readonly serviceDetail = inject(PromoCodeMasterDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::PromoCodeMasters';
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

  update(record: PromoCodeMasterWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: PromoCodeMasterWithNavigationPropertiesDto) {
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
      'CommonService.PromoCodeMasters.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.PromoCodeMasters.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
