import { CoreModule } from '@abp/ng.core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { ThemeLeptonXModule } from '@volosoft/abp.ng.theme.lepton-x';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';

@NgModule({
  declarations: [],
  imports: [
    CoreModule,
    ThemeSharedModule,
    ThemeLeptonXModule,
    CommercialUiModule,
    NgbDropdownModule,
    NgxValidateCoreModule
  ],
  exports: [
    CoreModule,
    ThemeSharedModule,
    ThemeLeptonXModule,
    CommercialUiModule,
    NgbDropdownModule,
    NgxValidateCoreModule
  ],
  providers: []
})
export class SharedModule {}
