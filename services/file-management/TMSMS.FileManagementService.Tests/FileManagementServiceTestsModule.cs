﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TMSMS.FileManagementService.Data;
using Volo.Abp;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.FileManagement;
using Volo.Abp.Uow;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;

namespace TMSMS.FileManagementService.Tests;

/* This project has a dotnet project reference to the TMSMS.FileManagementService project,
 * but it does not have a module dependency to the TMSMSFileManagementServiceModule module class.
 * Because, TMSMSFileManagementServiceModule has configurations proper for development and production
 * environments, but not proper or necessary for tests.
 *
 * In this test project, we are carefully depending on the modules that we need in tests.
 *
 * For example, TMSMSFileManagementServiceModule depends on AbpEventBusRabbitMqModule,
 * but this module depends on AbpEventBusModule since we don't want to use RabbitMQ in tests.
 * AbpEventBusModule has an in-process event bus instead of a real distributed event bus, and it is fine for tests.
 *
 * WARNING: If you change TMSMSFileManagementServiceModule class, you may need to properly change this class to keep
 *          test code compatible with the application code.
 */
[DependsOn(
    typeof(AbpAspNetCoreTestBaseModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqliteModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(FileManagementEntityFrameworkCoreModule),
    typeof(AbpEventBusModule),
    typeof(AbpCachingModule),
    typeof(AbpDistributedLockingAbstractionsModule)
)]
[AdditionalAssembly(typeof(TMSMSFileManagementServiceModule))]
public class FileManagementServiceTestsModule : AbpModule
{
    private SqliteConnection? _sqliteConnection;
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        ConfigureAuthorization(context);
        ConfigureDatabase(context);
        ConfigureDatabaseTransactions(context);
        ConfigureDynamicStores();
        ConfigureBackgroundJobs();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        app.UseCorrelationId();
        app.UseAbpRequestLocalization();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }

    public override async Task OnPreApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        using var scope = context.ServiceProvider.CreateScope();
        await scope.ServiceProvider
            .GetRequiredService<FileManagementServiceDataSeeder>()
            .SeedAsync();
    }
    
    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection?.Dispose();
    }

    private static void ConfigureAuthorization(ServiceConfigurationContext context)
    {
        /* We don't need to authorization in tests */
        context.Services.AddAlwaysAllowAuthorization();
    }

    private void ConfigureDatabase(ServiceConfigurationContext context)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();
        
        context.Services.AddAbpDbContext<FileManagementServiceDbContext>(options =>
        {
            options.AddDefaultRepositories();
        });
        
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(opts =>
            {
                /* Use SQLite for all EF Core DbContexts in tests */
                opts.UseSqlite(_sqliteConnection);
            });
        });
    }
    
    private void ConfigureDatabaseTransactions(ServiceConfigurationContext context)
    {
        context.Services.AddAlwaysDisableUnitOfWorkTransaction();
        
        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }
    
    private void ConfigureDynamicStores()
    {
        Configure<FeatureManagementOptions>(options =>
        {
            options.SaveStaticFeaturesToDatabase = false;
            options.IsDynamicFeatureStoreEnabled = false;
        });
        
        Configure<PermissionManagementOptions>(options =>
        {
            options.SaveStaticPermissionsToDatabase = false;
            options.IsDynamicPermissionStoreEnabled = false;
        });

        Configure<SettingManagementOptions>(options =>
        {
            options.SaveStaticSettingsToDatabase = false;
            options.IsDynamicSettingStoreEnabled = false;
        });
        
        //TODO: text templates
    }
    
    private void ConfigureBackgroundJobs()
    {
        Configure<AbpBackgroundWorkerOptions>(options =>
        {
            options.IsEnabled = false;
        });
        
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });
    }

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        // FileManagementServiceDbContext ()
        new FileManagementServiceDbContext(
            new DbContextOptionsBuilder<FileManagementServiceDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();
        
        // PermissionManagementDbContext
        new PermissionManagementDbContext(
            new DbContextOptionsBuilder<PermissionManagementDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();
        
        // FeatureManagementDbContext
        new FeatureManagementDbContext(
            new DbContextOptionsBuilder<FeatureManagementDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();
        
        // SettingManagementDbContext
        new SettingManagementDbContext(
            new DbContextOptionsBuilder<SettingManagementDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();
        
        // BlobStoringDbContext
        new BlobStoringDbContext(
            new DbContextOptionsBuilder<BlobStoringDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }
}
