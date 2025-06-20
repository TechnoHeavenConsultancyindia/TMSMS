import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [authGuard, permissionGuard],
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@volo/abp.ng.account/public').then(m => m.AccountPublicModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@volo/abp.ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
     path: 'openiddict',
     loadChildren: () => import('@volo/abp.ng.openiddictpro').then(m => m.OpeniddictproModule.forLazy()),
  },
    {
        path: 'gdpr',
        loadChildren: () => import('@volo/abp.ng.gdpr').then(m => m.GdprModule.forLazy()),
    },
  {
  path: 'gdpr-cookie-consent',
    loadChildren: () =>
      import('./gdpr-cookie-consent/gdpr-cookie-consent.module').then(
      m => m.GdprCookieConsentModule
    ),
  },
    {
        path: 'file-management',
        loadChildren: () => import('@volo/abp.ng.file-management').then(m => m.FileManagementModule.forLazy()),
    },
    {
        path: 'chat',
        loadChildren: () => import('@volo/abp.ng.chat').then(m => m.ChatModule.forLazy()),
    },
  {
    path: 'language-management',
    loadChildren: () =>
      import('@volo/abp.ng.language-management').then(m => m.LanguageManagementModule.forLazy()),
  },
  {
    path: 'saas',
    loadChildren: () => import('@volo/abp.ng.saas').then(m => m.SaasModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () =>
      import('@volo/abp.ng.audit-logging').then(m => m.AuditLoggingModule.forLazy()),
  },
  {
    path: 'text-template-management',
    loadChildren: () =>
      import('@volo/abp.ng.text-template-management').then(m =>
        m.TextTemplateManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'tour-service', loadChildren: () => import('tour-service').then(m => m.TourServiceModule.forLazy()) },
  { path: 'common-service', loadChildren: () => import('common-service').then(m => m.CommonServiceModule.forLazy()) },
  { path: 'transfer-service', loadChildren: () => import('transfer-service').then(m => m.TransferServiceModule.forLazy()) },
  { path: 'visa-service', loadChildren: () => import('visa-service').then(m => m.VisaServiceModule.forLazy()) },
  { path: 'restaurant-service', loadChildren: () => import('restaurant-service').then(m => m.RestaurantServiceModule.forLazy()) },
  { path: 'agent-service', loadChildren: () => import('agent-service').then(m => m.AgentServiceModule.forLazy()) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
