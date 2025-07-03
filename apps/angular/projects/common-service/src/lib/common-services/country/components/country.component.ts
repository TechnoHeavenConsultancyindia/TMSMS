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
import { CountryViewService } from '../services/country.service';
import { CountryDetailViewService } from '../services/country-detail.service';
import { CountryDetailModalComponent } from './country-detail.component';
import {
  AbstractCountryComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './country.abstract.component';
import { GetCountriesInput } from '../../../proxy/common-service/common-services';
import { TechnoAdvancedEntityFiltersComponent } from 'projects/t-mSMS/src/app/custom-control/advanced-entity-filter/components/techno-advanced-entity-filters.component';

@Component({
  selector: 'lib-country',
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
    CountryDetailModalComponent,
    TechnoAdvancedEntityFiltersComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    CountryViewService,
    CountryDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './country.extended.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class CountryComponent extends AbstractCountryComponent implements OnInit {
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
      } as GetCountriesInput;
    }
    if (!this.isListQueryCreated) {
      this.service.hookToQuery();
      this.isListQueryCreated = true;
    }
    this.list.get();
  }

  clearFilters() {
    this.setErrorAndData(false);
    this.service.filters = {} as GetCountriesInput;
  }

  setErrorAndData(flag: boolean) {
    this.service.data.totalCount = 0;
    this.service.data.items = [];
  }
}
