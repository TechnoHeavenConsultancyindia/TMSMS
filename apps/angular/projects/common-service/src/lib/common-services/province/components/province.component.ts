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
import { ProvinceViewService } from '../services/province.service';
import { ProvinceDetailViewService } from '../services/province-detail.service';
import { ProvinceDetailModalComponent } from './province-detail.component';
import {
  AbstractProvinceComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './province.abstract.component';

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
export class ProvinceComponent extends AbstractProvinceComponent {}
