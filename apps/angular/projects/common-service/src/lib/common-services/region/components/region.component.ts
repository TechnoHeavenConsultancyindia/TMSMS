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
import { RegionViewService } from '../services/region.service';
import { RegionDetailViewService } from '../services/region-detail.service';
import { RegionDetailModalComponent } from './region-detail.component';
import {
  AbstractRegionComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './region.abstract.component';

@Component({
  selector: 'lib-region',
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
    RegionDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    RegionViewService,
    RegionDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './region.extended.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class RegionComponent extends AbstractRegionComponent {}
