import { PageModule } from '@abp/ng.components/page';
import { CoreModule, ListService } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { Component, ContentChild, Input } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbTimepickerModule, NgbDropdownModule, NgbDateAdapter, NgbTimeAdapter } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { AdvancedEntityFiltersComponent, AdvancedEntityFiltersFormComponent, CommercialUiModule } from '@volo/abp.commercial.ng.ui';

@Component({
  selector: 'abp-advanced-entity-filters-form',
  standalone: true,
  imports: [
    NgbCollapseModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    CoreModule,
    CommercialUiModule,
  ],
  template: ` <ng-content></ng-content> `,
})
export class TechnoAdvancedEntityFiltersFormComponent extends AdvancedEntityFiltersFormComponent { }

@Component({
  selector: 'techno-advanced-entity-filters',
  standalone: true,
  templateUrl: './techno-advanced-entity-filters.component.html',
  imports: [
    NgbCollapseModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    CoreModule,
    CommercialUiModule,
  ],
  providers: [
    ListService
  ],
})
export class TechnoAdvancedEntityFiltersComponent extends AdvancedEntityFiltersComponent {
  filtersHidden = false;
}
