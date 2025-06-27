import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { VisaTermCategoryDto } from '../../../proxy/visa-service/visa-services/models';
import { VisaTermCategoryViewService } from '../services/visa-term-category.service';
import { VisaTermCategoryDetailViewService } from '../services/visa-term-category-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractVisaTermCategoryComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(VisaTermCategoryViewService);
  public readonly serviceDetail = inject(VisaTermCategoryDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'VisaService::VisaTermCategories';
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

  update(record: VisaTermCategoryDto) {
    this.serviceDetail.update(record);
  }

  delete(record: VisaTermCategoryDto) {
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
      'VisaService.VisaTermCategories.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'VisaService.VisaTermCategories.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
