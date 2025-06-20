import { ModuleWithProviders, NgModule } from '@angular/core';
import { AGENT_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class AgentServiceConfigModule {
  static forRoot(): ModuleWithProviders<AgentServiceConfigModule> {
    return {
      ngModule: AgentServiceConfigModule,
      providers: [AGENT_SERVICE_ROUTE_PROVIDERS],
    };
  }
}
