import { ModuleWithProviders, NgModule } from '@angular/core';
import { AGENT_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';
import { AGENT_SERVICES_AGENT_GROUP_TYPE_ROUTE_PROVIDER } from './providers/agent-group-type-route.provider';
import { AGENT_SERVICES_AGENT_PERMISSION_TYPE_ROUTE_PROVIDER } from './providers/agent-permission-type-route.provider';
import { AGENT_SERVICES_AGENT_VOUCHER_TYPE_ROUTE_PROVIDER } from './providers/agent-voucher-type-route.provider';

@NgModule()
export class AgentServiceConfigModule {
  static forRoot(): ModuleWithProviders<AgentServiceConfigModule> {
    return {
      ngModule: AgentServiceConfigModule,
      providers: [
        AGENT_SERVICE_ROUTE_PROVIDERS,
        AGENT_SERVICES_AGENT_GROUP_TYPE_ROUTE_PROVIDER,
        AGENT_SERVICES_AGENT_PERMISSION_TYPE_ROUTE_PROVIDER,
        AGENT_SERVICES_AGENT_VOUCHER_TYPE_ROUTE_PROVIDER,
      ],
    };
  }
}
