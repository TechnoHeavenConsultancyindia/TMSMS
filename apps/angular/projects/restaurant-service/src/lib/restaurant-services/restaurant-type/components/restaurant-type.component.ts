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

import { RestaurantTypeViewService } from '../services/restaurant-type.service';
import { RestaurantTypeDetailViewService } from '../services/restaurant-type-detail.service';
import { RestaurantTypeDetailModalComponent } from './restaurant-type-detail.component';
import {
  AbstractRestaurantTypeComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './restaurant-type.abstract.component';

@Component({
  selector: 'lib-restaurant-type',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
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
    RestaurantTypeDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    RestaurantTypeViewService,
    RestaurantTypeDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './restaurant-type.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class RestaurantTypeComponent extends AbstractRestaurantTypeComponent {}
