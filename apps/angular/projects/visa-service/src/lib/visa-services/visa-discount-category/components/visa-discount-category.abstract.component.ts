import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { VisaDiscountCategoryDto } from '../../../proxy/visa-service/visa-services/models';
import { VisaDiscountCategoryViewService } from '../services/visa-discount-category.service';
import { VisaDiscountCategoryDetailViewService } from '../services/visa-discount-category-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractVisaDiscountCategoryComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(VisaDiscountCategoryViewService);
  public readonly serviceDetail = inject(VisaDiscountCategoryDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'VisaService::DiscountCategories';
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

  update(record: VisaDiscountCategoryDto) {
    this.serviceDetail.update(record);
  }

  delete(record: VisaDiscountCategoryDto) {
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
      'VisaService.VisaDiscountCategories.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'VisaService.VisaDiscountCategories.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
