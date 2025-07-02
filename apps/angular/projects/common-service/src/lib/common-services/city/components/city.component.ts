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
import { CityViewService } from '../services/city.service';
import { CityDetailViewService } from '../services/city-detail.service';
import { CityDetailModalComponent } from './city-detail.component';
import {
  AbstractCityComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './city.abstract.component';
import { GetCitiesInput } from '../../../proxy/common-service/common-services/models';
import { TechnoAdvancedEntityFiltersComponent } from 'projects/t-mSMS/src/app/custom-control/advanced-entity-filter/components/techno-advanced-entity-filters.component';

@Component({
  selector: 'lib-city',
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
    CityDetailModalComponent,
    TechnoAdvancedEntityFiltersComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    CityViewService,
    CityDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './city.extended.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class CityComponent extends AbstractCityComponent implements OnInit {
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
      } as GetCitiesInput;
    }
    if (!this.isListQueryCreated) {
      this.service.hookToQuery();
      this.isListQueryCreated = true;
    }
    this.list.get();
  }

  clearFilters() {
    this.setErrorAndData(false);
    this.service.filters = {} as GetCitiesInput;
  }

  setErrorAndData(flag: boolean) {
    this.service.data.totalCount = 0;
    this.service.data.items = [];
  }
}
