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
import { ProvinceViewService } from '../services/province.service';
import { ProvinceDetailViewService } from '../services/province-detail.service';
import { ProvinceDetailModalComponent } from './province-detail.component';
import {
  AbstractProvinceComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './province.abstract.component';
import { GetProvincesInput } from '../../../proxy/common-service/common-services';
import { TechnoAdvancedEntityFiltersComponent } from 'projects/t-mSMS/src/app/custom-control/advanced-entity-filter/components/techno-advanced-entity-filters.component';

@Component({
  selector: 'lib-province',
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
    ProvinceDetailModalComponent,
    TechnoAdvancedEntityFiltersComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    ProvinceViewService,
    ProvinceDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './province.extended.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class ProvinceComponent extends AbstractProvinceComponent implements OnInit {
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
      } as GetProvincesInput;
    }
    if (!this.isListQueryCreated) {
      this.service.hookToQuery();
      this.isListQueryCreated = true;
    }
    this.list.get();
  }

  clearFilters() {
    this.setErrorAndData(false);
    this.service.filters = {} as GetProvincesInput;
  }

  setErrorAndData(flag: boolean) {
    this.service.data.totalCount = 0;
    this.service.data.items = [];
  }
}
