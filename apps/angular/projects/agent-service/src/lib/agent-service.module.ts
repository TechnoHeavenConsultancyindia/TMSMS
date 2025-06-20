import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AgentServiceRoutingModule } from './agent-service-routing.module';

@NgModule({
  declarations: [],
  imports: [CoreModule, ThemeSharedModule, AgentServiceRoutingModule],
  exports: [],
})
export class AgentServiceModule {
  static forChild(): ModuleWithProviders<AgentServiceModule> {
    return {
      ngModule: AgentServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AgentServiceModule> {
    return new LazyModuleFactory(AgentServiceModule.forChild());
  }
}
