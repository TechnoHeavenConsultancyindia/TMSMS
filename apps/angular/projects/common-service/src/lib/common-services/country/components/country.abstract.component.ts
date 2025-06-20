import { Directive, OnInit, inject } from '@angular/core';

import { ListService, PermissionService, TrackByService } from '@abp/ng.core';

import type { CountryDto } from '../../../proxy/common-service/common-services/models';
import { CountryViewService } from '../services/country.service';
import { CountryDetailViewService } from '../services/country-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive()
export abstract class AbstractCountryComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(CountryViewService);
  public readonly serviceDetail = inject(CountryDetailViewService);
  public readonly permissionService = inject(PermissionService);

  protected title = 'CommonService::Countries';
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

  update(record: CountryDto) {
    this.serviceDetail.update(record);
  }

  delete(record: CountryDto) {
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
      'CommonService.Countries.Edit',
    );
    const canDelete = this.permissionService.getGrantedPolicy(
      'CommonService.Countries.Delete',
    );
    this.isActionButtonVisible = canEdit || canDelete;
  }
}
