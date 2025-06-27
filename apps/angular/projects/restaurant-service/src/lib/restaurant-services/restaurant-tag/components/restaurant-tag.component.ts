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
import { RestaurantTagViewService } from '../services/restaurant-tag.service';
import { RestaurantTagDetailViewService } from '../services/restaurant-tag-detail.service';
import { RestaurantTagDetailModalComponent } from './restaurant-tag-detail.component';
import {
  AbstractRestaurantTagComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './restaurant-tag.abstract.component';

@Component({
  selector: 'lib-restaurant-tag',
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
    RestaurantTagDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    RestaurantTagViewService,
    RestaurantTagDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './restaurant-tag.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class RestaurantTagComponent extends AbstractRestaurantTagComponent {}
