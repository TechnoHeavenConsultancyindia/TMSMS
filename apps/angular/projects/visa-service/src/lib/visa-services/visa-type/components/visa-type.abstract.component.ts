import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { VisaTypeDto } from '../../../proxy/visa-service/visa-services/models';
import { VisaTypeViewService } from '../services/visa-type.service';
import { VisaTypeDetailViewService } from '../services/visa-type-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractVisaTypeComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(VisaTypeViewService);
  public readonly serviceDetail = inject(VisaTypeDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'VisaService::VisaTypes';
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

  update(record: VisaTypeDto) {
    this.serviceDetail.update(record);
  }

  delete(record: VisaTypeDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }

  checkActionButtonVisibility() {
    if (this.isActionButtonVisible !== null) {
      return;
    }

    const canEdit = this.permissionService.getGrantedPolicy('VisaService.VisaTypes.Edit');
    const canDelete = this.permissionService.getGrantedPolicy(
      'VisaService.VisaTypes.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
