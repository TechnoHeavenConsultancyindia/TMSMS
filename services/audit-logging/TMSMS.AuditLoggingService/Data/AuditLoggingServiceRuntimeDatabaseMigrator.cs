﻿using Volo.Abp.DistributedLocking;
using Volo.Abp.EntityFrameworkCore.Migrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TMSMS.AuditLoggingService.Data;

public class AuditLoggingServiceRuntimeDatabaseMigrator : EfCoreRuntimeDatabaseMigratorBase<AuditLoggingServiceDbContext>
{
    private readonly AuditLoggingServiceDataSeeder _dataSeeder;

    public AuditLoggingServiceRuntimeDatabaseMigrator(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IAbpDistributedLock abpDistributedLock,
        IDistributedEventBus distributedEventBus,
        AuditLoggingServiceDataSeeder dataSeeder
    ) : base(
        AuditLoggingServiceDbContext.DatabaseName,
        unitOfWorkManager,
        serviceProvider,
        currentTenant,
        abpDistributedLock,
        distributedEventBus,
        loggerFactory)
    {
        _dataSeeder = dataSeeder;
    }

    protected override async Task SeedAsync()
    {
        await _dataSeeder.SeedAsync();
    }
}