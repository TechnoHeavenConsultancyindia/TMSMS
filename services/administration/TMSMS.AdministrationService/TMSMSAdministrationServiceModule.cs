using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.HttpApi;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Authentication.JwtBearer.DynamicClaims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Serilog;
using Microsoft.OpenApi.Models;
using TMSMS.AdministrationService.Data;
using Prometheus;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Data;
using Volo.Abp.Uow;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Swashbuckle;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Emailing;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Studio.Client.AspNetCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.AuditLogging;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.MultiTenancy;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.OpenIddict;
using Volo.Abp.LeptonXTheme.Management;
using TMSMS.AdministrationService.HealthChecks;

namespace TMSMS.AdministrationService;

[DependsOn(
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(TextTemplateManagementEntityFrameworkCoreModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(LanguageManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpOpenIddictProDomainSharedModule),
    typeof(TextTemplateManagementApplicationModule),
    typeof(TextTemplateManagementHttpApiModule),
    typeof(LeptonXThemeManagementApplicationModule),
    typeof(LeptonXThemeManagementHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(TMSMSAdministrationServiceContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpBackgroundJobsRabbitMqModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpStudioClientAspNetCoreModule)
)]
public class TMSMSAdministrationServiceModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<WebRemoteDynamicClaimsPrincipalContributorOptions>(options =>
        {
            options.IsEnabled = true;
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var env = context.Services.GetHostingEnvironment();
        
        var redis = CreateRedisConnection(configuration);

        ConfigurePII(configuration);
        ConfigureMultiTenancy();
        ConfigureJwtBearer(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureSwagger(context, configuration);
        ConfigureDatabase(context);
        ConfigureDistributedCache(configuration);
        ConfigureDataProtection(context, configuration, redis);
        ConfigureDistributedLock(context, redis);
        ConfigureDistributedEventBus();
        ConfigurePermissionManagement();
        ConfigureFeatureManagement();
        ConfigureSettingManagement();
        ConfigureTextTemplateManagement();
        ConfigureIntegrationServices();
        ConfigureAntiForgery(env);
        ConfigureAutoControllers();
        ConfigureVirtualFileSystem();
        ConfigureDynamicClaims(context);
        ConfigureEmailSender(context);
        ConfigureHealthChecks(context);
        context.Services.TransformAbpClaims();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.GetConfiguration();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCorrelationId();
        app.UseAbpRequestLocalization();
        //app.UseAbpSecurityHeaders(); //TODO: Enable security headers ??? I suppose no need for an API
        app.UseRouting();
        app.MapAbpStaticAssets();
        app.UseAbpStudioLink();
        app.UseCors();
        app.UseHttpMetrics();
        app.UseAuthentication();
        app.UseMultiTenancy();
        app.UseAuthorization();

        if (IsSwaggerEnabled(configuration))
        {
            app.UseSwagger();
            app.UseAbpSwaggerUI(options => ConfigureSwaggerUI(options, configuration) );
        }
        
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseConfiguredEndpoints(endpoints =>
        {
            endpoints.MapMetrics();
        });
    }
    
    public override async Task OnPreApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        using var scope = context.ServiceProvider.CreateScope();
        await MigrateDatabase(scope.ServiceProvider);
    }

    private static async Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        await serviceProvider
            .GetRequiredService<AdministrationServiceRuntimeDatabaseMigrator>()
            .CheckAndApplyDatabaseMigrationsAsync();
        
        await serviceProvider
            .GetRequiredService<BlobStoringRuntimeDatabaseMigrator>()
            .CheckAndApplyDatabaseMigrationsAsync();
    }

    private ConnectionMultiplexer CreateRedisConnection(IConfiguration configuration)
    {
        return ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
    }

    private void ConfigureHealthChecks(ServiceConfigurationContext context)
    {
        context.Services.AddAdministrationServiceHealthChecks();
    }

    private void ConfigureVirtualFileSystem()
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TMSMSAdministrationServiceModule>();
        });
    }
    
    private void ConfigurePII(IConfiguration configuration)
    {
        if (configuration.GetValue<bool>(configuration["App:EnablePII"] ?? "false"))
        {
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.LogCompleteSecurityArtifact = true;
        }
    }

    private void ConfigureMultiTenancy()
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });
    }

    private void ConfigureJwtBearer(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddAbpJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.MetadataAddress = configuration["AuthServer:MetaAddress"]!.EnsureEndsWith('/') + ".well-known/openid-configuration";
                options.RequireHttpsMetadata = configuration.GetValue<bool>(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = configuration["AuthServer:Audience"];
            });
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var corsOrigins = configuration["App:CorsOrigins"];
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                if (!corsOrigins.IsNullOrEmpty())
                {
                    builder
                        .WithOrigins(
                            corsOrigins!
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                }
            });
        });
    }

    private void ConfigureSwagger(ServiceConfigurationContext context, IConfiguration configuration)
    {
        if (IsSwaggerEnabled(configuration))
        {
            context.Services.AddAbpSwaggerGenWithOAuth(
                authority: configuration["AuthServer:Authority"],
                scopes: new Dictionary<string, string>
                {
                    {"AdministrationService", "Administration Service API"}
                },
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Administration API", Version = "v1"});
                    options.DocInclusionPredicate((_, _) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }
    }

    private void ConfigureDatabase(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.Databases.Configure(AdministrationServiceDbContext.DatabaseName, database =>
            {
                database.MappedConnections.Add(AbpPermissionManagementDbProperties.ConnectionStringName);
                database.MappedConnections.Add(AbpFeatureManagementDbProperties.ConnectionStringName);
                database.MappedConnections.Add(AbpSettingManagementDbProperties.ConnectionStringName);
            });
            
            options.Databases.Configure("AuditLoggingService", database =>
            {
                database.MappedConnections.Add(AbpAuditLoggingDbProperties.ConnectionStringName);
            });
            
            options.Databases.Configure("SaasService", database =>
            {
                database.MappedConnections.Add(SaasDbProperties.ConnectionStringName);
            });
            
            options.Databases.Configure("LanguageService", database =>
            {
                database.MappedConnections.Add(LanguageManagementDbProperties.ConnectionStringName);
            });
        });

        context.Services.AddAbpDbContext<AdministrationServiceDbContext>(options =>
        {
            options.AddDefaultRepositories();
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(opts =>
            {
                /* Sets default DBMS for this service */
                opts.UseSqlServer();
            });

            options.Configure<AdministrationServiceDbContext>(c =>
            {
                c.UseSqlServer(b =>
                {
                    b.MigrationsHistoryTable("__AdministrationService_Migrations");
                });
            });
            
            options.Configure<BlobStoringDbContext>(c =>
            {
                c.UseSqlServer(b =>
                {
                    b.MigrationsHistoryTable("__AbpBlobStoring_Migrations");
                    b.MigrationsAssembly(typeof(TMSMSAdministrationServiceModule).Assembly.GetName().Name);
                });
            });
        });

    }
    
    private void ConfigureDistributedCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = configuration["AbpDistributedCache:KeyPrefix"] ?? "";
        });
    }
    
    private void ConfigureDataProtection(ServiceConfigurationContext context, IConfiguration configuration, IConnectionMultiplexer redis)
    {
        context.Services
            .AddDataProtection()
            .SetApplicationName(configuration["DataProtection:ApplicationName"]!)
            .PersistKeysToStackExchangeRedis(redis, configuration["DataProtection:Keys"]);
    }

    private void ConfigureDistributedLock(ServiceConfigurationContext context, IConnectionMultiplexer redis)
    {
        context.Services.AddSingleton<IDistributedLockProvider>(
            _ => new RedisDistributedSynchronizationProvider(redis.GetDatabase())
        );
    }

    private void ConfigureDistributedEventBus()
    {
        Configure<AbpDistributedEventBusOptions>(options =>
        {
            options.Inboxes.Configure(config =>
            {
                config.UseDbContext<AdministrationServiceDbContext>();
            });

            options.Outboxes.Configure(config =>
            {
                config.UseDbContext<AdministrationServiceDbContext>();
            });
        });
    }
    
    private void ConfigurePermissionManagement()
    {
        Configure<PermissionManagementOptions>(options =>
        {
            options.IsDynamicPermissionStoreEnabled = true;
        });
    }
    
    private void ConfigureFeatureManagement()
    {
        Configure<FeatureManagementOptions>(options =>
        {
            options.IsDynamicFeatureStoreEnabled = true;
        });
    }
    
    private void ConfigureSettingManagement()
    {
        Configure<SettingManagementOptions>(options =>
        {
            options.IsDynamicSettingStoreEnabled = true;
        });
    }

    private void ConfigureTextTemplateManagement()
    {
        Configure<TextTemplateManagementOptions>(options =>
        {
            options.IsDynamicTemplateStoreEnabled = true;
        });
    }

    private void ConfigureIntegrationServices()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ExposeIntegrationServices = true;
        });
    }
    
    private void ConfigureAutoControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options
                .ConventionalControllers
                .Create(typeof(TMSMSAdministrationServiceModule).Assembly, opts =>
                {
                    opts.RemoteServiceName = "AdministrationService";
                    opts.RootPath = "administration";
                });
        });
    }

    private void ConfigureAntiForgery(IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            Configure<AbpAntiForgeryOptions>(options =>
            {
                /* Disabling ABP's auto anti forgery validation feature, because
                 * when we run the application in "localhost" domain, it will share
                 * the cookies between other applications (like the authentication server)
                 * and anti-forgery validation filter uses the other application's tokens
                 * which will fail the process unnecessarily.
                 */
                options.AutoValidate = false;
            });
        }
    }
    
    private static void ConfigureSwaggerUI(SwaggerUIOptions options, IConfiguration configuration)
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Administration API");
        options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        options.OAuthScopes("AdministrationService");
    }
    
    private static bool IsSwaggerEnabled(IConfiguration configuration)
    {
        return bool.Parse(configuration["Swagger:IsEnabled"] ?? "true");
    }

    private void ConfigureDynamicClaims(ServiceConfigurationContext context)
    {
        context.Services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            options.IsDynamicClaimsEnabled = true;
        });
    }

    private void ConfigureEmailSender(ServiceConfigurationContext context)
    {
#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
