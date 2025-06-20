import { CoreModule, provideAbpCore, withOptions } from '@abp/ng.core';
import { provideAbpOAuth } from '@abp/ng.oauth';
import { provideSettingManagementConfig } from '@abp/ng.setting-management/config';
import { provideFeatureManagementConfig } from '@abp/ng.feature-management';
import { ThemeSharedModule, withValidationBluePrint, provideAbpThemeShared,withHttpErrorConfig} from '@abp/ng.theme.shared';
import { IdentityConfigModule, provideIdentityConfig } from '@volo/abp.ng.identity/config';
import { provideCommercialUiConfig } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule, provideAccountAdminConfig } from '@volo/abp.ng.account/admin/config';
import { provideAccountPublicConfig } from '@volo/abp.ng.account/public/config';
import { GdprConfigModule, provideGdprConfig, withCookieConsentOptions } from '@volo/abp.ng.gdpr/config';
import { AuditLoggingConfigModule, provideAuditLoggingConfig } from '@volo/abp.ng.audit-logging/config';
import { provideLanguageManagementConfig } from '@volo/abp.ng.language-management/config';
import { registerLocale } from '@volo/abp.ng.language-management/locale';
import { provideFileManagementConfig } from '@volo/abp.ng.file-management/config';
import { provideChatConfig } from '@volo/abp.ng.chat/config';
import { provideSaasConfig } from '@volo/abp.ng.saas/config';
import { provideTextTemplateManagementConfig } from '@volo/abp.ng.text-template-management/config';
import { provideOpeniddictproConfig } from '@volo/abp.ng.openiddictpro/config';
import { HttpErrorComponent, ThemeLeptonXModule } from '@volosoft/abp.ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@volosoft/abp.ng.theme.lepton-x/layouts';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { TourServiceConfigModule } from 'tour-service/config';
import { CommonServiceConfigModule } from 'common-service/config';
import { TransferServiceConfigModule } from 'transfer-service/config';
import { VisaServiceConfigModule } from 'visa-service/config';
import { RestaurantServiceConfigModule } from 'restaurant-service/config';
import { AgentServiceConfigModule } from 'agent-service/config';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ThemeSharedModule,
    CoreModule,
    IdentityConfigModule,
    AccountAdminConfigModule,
    GdprConfigModule,
    AuditLoggingConfigModule,
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    TourServiceConfigModule.forRoot(),
    CommonServiceConfigModule.forRoot(),
    TransferServiceConfigModule.forRoot(),
    VisaServiceConfigModule.forRoot(),
    RestaurantServiceConfigModule.forRoot(),
    AgentServiceConfigModule.forRoot(),
  ],
  providers: [
    APP_ROUTE_PROVIDER,
    provideAbpCore(
      withOptions({
        environment,
        registerLocaleFn: registerLocale(),
        localizations: [
            {
                culture: 'en',
                resources: [
                    {
                        resourceName: 'TMSMS',
                        texts: {
                            "Menu:Home": "Home",
                            "Login": "Login",
                            "Menu:Dashboard": "Dashboard",
                            "LongWelcomeMessage": "Welcome to the application. This is a startup project based on the ABP framework. For more information visit",
                            "Welcome": "Welcome"
                        }
                    }
                ]
            }
        ]
      }),
    ),
    provideAbpOAuth(),
    provideIdentityConfig(),
    provideSettingManagementConfig(),
    provideFeatureManagementConfig(),
    provideAccountAdminConfig(),
    provideAccountPublicConfig(),
    provideCommercialUiConfig(),
    provideAbpThemeShared(
      withHttpErrorConfig({
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      }),
      withValidationBluePrint({
        wrongPassword: 'Please choose 1q2w3E*',
      }),
    ),
    provideGdprConfig(
      withCookieConsentOptions({
        cookiePolicyUrl: '/gdpr-cookie-consent/cookie',
        privacyPolicyUrl: '/gdpr-cookie-consent/privacy',
      }),
    ),
    provideLanguageManagementConfig(),
    provideFileManagementConfig(),
    provideSaasConfig(),
    provideChatConfig(),
    provideAuditLoggingConfig(),
    provideOpeniddictproConfig(),
    provideTextTemplateManagementConfig(),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
