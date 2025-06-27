import { Environment } from '@abp/ng.core';

const baseUrl = 'http://172.10.1.67:4200';

const oAuthConfig = {
  issuer: 'http://172.10.1.181:44323/',
  redirectUri: baseUrl,
  clientId: 'AngularKhyati',
  responseType: 'code',
  scope: 'offline_access openid profile email phone AuthServer IdentityService AdministrationService AuditLoggingService GdprService ChatService SaasService FileManagementService LanguageService TourService CommonService TransferService VisaService RestaurantService AgentService',
  requireHttps: false,
  impersonation: {
    tenantImpersonation: true,
    userImpersonation: true,
  }
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'TMSMS',
  }, 
  localization: {
    defaultResourceName: 'TMSMS'
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'http://172.10.1.67:44331',
      rootNamespace: 'TMSMS',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
