import { CoreModule, ListService } from '@abp/ng.core';
import { DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { Component, Input, ViewEncapsulation } from '@angular/core';
import { NgbDropdownModule, NgbDateAdapter, NgbTimeAdapter } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

@Component({
  selector: 'techno-entity-filter',
  templateUrl: './techno-entity-filter.component.html',
  standalone: true,
  imports: [
    NgbDropdownModule,
    NgxValidateCoreModule,
    CoreModule,
    CommercialUiModule,
  ],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  encapsulation: ViewEncapsulation.None,
})
export class TechnoEntityFilterComponent {
  @Input() list: ListService<any>;
  @Input() placeholder = '';
}
