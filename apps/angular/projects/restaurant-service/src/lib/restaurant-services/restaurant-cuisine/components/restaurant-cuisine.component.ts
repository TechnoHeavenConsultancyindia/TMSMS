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
import { RestaurantCuisineViewService } from '../services/restaurant-cuisine.service';
import { RestaurantCuisineDetailViewService } from '../services/restaurant-cuisine-detail.service';
import { RestaurantCuisineDetailModalComponent } from './restaurant-cuisine-detail.component';
import {
  AbstractRestaurantCuisineComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './restaurant-cuisine.abstract.component';

@Component({
  selector: 'lib-restaurant-cuisine',
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
    RestaurantCuisineDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    RestaurantCuisineViewService,
    RestaurantCuisineDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './restaurant-cuisine.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class RestaurantCuisineComponent extends AbstractRestaurantCuisineComponent {}
