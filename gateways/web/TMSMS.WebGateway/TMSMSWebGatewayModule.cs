using System;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp.Studio.Client.AspNetCore;
using Volo.Abp.Swashbuckle;
using Yarp.ReverseProxy.Configuration;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.MultiTenancy;
using TMSMS.WebGateway.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace TMSMS.WebGateway;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpStudioClientAspNetCoreModule)
)]
public class TMSMSWebGatewayModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureCors(context, configuration);
        ConfigureMultiTenancy();
        ConfigureSwagger(context, configuration);
        ConfigureYarp(context, configuration);
        ConfigureHealthChecks(context);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.GetConfiguration();
        var proxyConfig = app.ApplicationServices.GetRequiredService<IProxyConfigProvider>().GetConfig();
        var healthCheckUrl = configuration["App:HealthCheckUrl"];
        if (string.IsNullOrEmpty(healthCheckUrl))
        {
            healthCheckUrl = "/health-status";
        }

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.MapAbpStaticAssets();
        app.UseAbpStudioLink();
        app.UseCors();
        app.UseAuthorization();
        
        if (IsSwaggerEnabled(configuration))
        {
            app.UseSwagger();
            app.UseAbpSwaggerUI(options => { ConfigureSwaggerUI(proxyConfig, options, configuration); });
            app.UseRewriter(CreateSwaggerRewriteOptions());
        }
        
        app.UseHealthChecksUI(options => 
        { 
            options.UIPath = "/health-ui"; 
            options.ApiPath = "/health-api"; 
        });

        app.UseAbpSerilogEnrichers();
        app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
                endpoints.MapHealthChecks(healthCheckUrl, new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json; charset=utf-8";
                        var result = JsonSerializer.Serialize(new
                        {
                            status = report.Status.ToString(),
                            checks = report.Entries.Select(e => new
                            {
                                name = e.Key,
                                status = e.Value.Status.ToString(),
                                description = e.Value.Description ?? "No description",
                                data = e.Value.Data
                            }),
                            totalDuration = report.TotalDuration.ToString()
                        });

                        await context.Response.WriteAsync(result);
                    }
                });
            }
        );
    }

    private void ConfigureMultiTenancy()
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });
    }

    private void ConfigureYarp(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"))
            .AddConfigFilter<WebGatewayConfigFilter>();
    }

    private void ConfigureHealthChecks(ServiceConfigurationContext context)
    {
        context.Services.AddWebGatewayHealthChecks();
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

    private static bool IsSwaggerEnabled(IConfiguration configuration)
    {
        return bool.Parse(configuration["Swagger:IsEnabled"] ?? "true");
    }

    private void ConfigureSwagger(ServiceConfigurationContext context, IConfiguration configuration)
    {
        if (IsSwaggerEnabled(configuration))
        {
            context.Services.AddAbpSwaggerGen();
        }
    }

    private static void ConfigureSwaggerUI(
        IProxyConfig proxyConfig,
        SwaggerUIOptions options,
        IConfiguration configuration)
    {
        foreach (var cluster in proxyConfig.Clusters)
        {
            options.SwaggerEndpoint($"/swagger-json/{cluster.ClusterId}/swagger/v1/swagger.json", $"{cluster.ClusterId} API");
        }

        options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        options.OAuthScopes(
            "AgentService",
            "RestaurantService",
            "VisaService",
            "TransferService",
            "CommonService",
            "TourService",
            "AdministrationService",
            "AuthServer",
            "SaasService",
            "AuditLoggingService",
            "GdprService",
            "ChatService",
            "FileManagementService",
            "LanguageService",
            "IdentityService"
        );
    }
    
    private static RewriteOptions CreateSwaggerRewriteOptions()
    {
        var rewriteOptions = new RewriteOptions();
        rewriteOptions.AddRedirect("^(|\\|\\s+)$", "/swagger"); // Regex for "/" and "" (whitespace)
        return rewriteOptions;
    }
}