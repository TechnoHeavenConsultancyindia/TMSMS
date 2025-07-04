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
import { WeekDayViewService } from '../services/week-day.service';
import { WeekDayDetailViewService } from '../services/week-day-detail.service';
import { WeekDayDetailModalComponent } from './week-day-detail.component';
import {
  AbstractWeekDayComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './week-day.abstract.component';

@Component({
  selector: 'lib-week-day',
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
    WeekDayDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    WeekDayViewService,
    WeekDayDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './week-day.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class WeekDayComponent extends AbstractWeekDayComponent {}
