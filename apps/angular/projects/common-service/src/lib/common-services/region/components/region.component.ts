import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { RegionViewService } from '../services/region.service';
import { RegionDetailViewService } from '../services/region-detail.service';
import { RegionDetailModalComponent } from './region-detail.component';
import {
  AbstractRegionComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './region.abstract.component';
import { TechnoAdvancedEntityFiltersComponent } from 'projects/t-mSMS/src/app/custom-control/advanced-entity-filter/components/techno-advanced-entity-filters.component';
import { GetRegionsInput } from '../../../proxy/common-service/common-services';

@Component({
  selector: 'lib-region',
  changeDetection: ChangeDetectionStrategy.Default,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    RegionDetailModalComponent,
    TechnoAdvancedEntityFiltersComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    RegionViewService,
    RegionDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './region.extended.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class RegionComponent extends AbstractRegionComponent implements OnInit {
  protected isListQueryCreated: boolean = false;
  filtersHidden = true;

  ngOnInit() { }

  searchResults() {
    if (this.filtersHidden) {
      this.service.filters = {
        'name': this.service.filters.name,
        'fullName': this.service.filters.fullName,
        'countryCode': this.service.filters.countryCode,
        'countrySubdivisionCode': this.service.filters.countrySubdivisionCode,
      } as GetRegionsInput;
    }
    if (!this.isListQueryCreated) {
      this.service.hookToQuery();
      this.isListQueryCreated = true;
    }
    this.list.get();
  }

  clearFilters() {
    this.setErrorAndData(false);
    this.service.filters = {} as GetRegionsInput;
  }

  setErrorAndData(flag: boolean) {
    this.service.data.totalCount = 0;
    this.service.data.items = [];
  }
}
