import { ChangeDetectionStrategy, Component } from '@angular/core';
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
import { RestaurantDietaryTypeViewService } from '../services/restaurant-dietary-type.service';
import { RestaurantDietaryTypeDetailViewService } from '../services/restaurant-dietary-type-detail.service';
import { RestaurantDietaryTypeDetailModalComponent } from './restaurant-dietary-type-detail.component';
import {
  AbstractRestaurantDietaryTypeComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './restaurant-dietary-type.abstract.component';

@Component({
  selector: 'lib-restaurant-dietary-type',
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
    RestaurantDietaryTypeDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    RestaurantDietaryTypeViewService,
    RestaurantDietaryTypeDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './restaurant-dietary-type.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class RestaurantDietaryTypeComponent extends AbstractRestaurantDietaryTypeComponent {}
