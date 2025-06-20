using Volo.Abp.DistributedLocking;
using Volo.Abp.EntityFrameworkCore.Migrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TMSMS.AgentService.Data;

public class AgentServiceRuntimeDatabaseMigrator : EfCoreRuntimeDatabaseMigratorBase<AgentServiceDbContext>
{
    private readonly AgentServiceDataSeeder _dataSeeder;

    public AgentServiceRuntimeDatabaseMigrator(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IAbpDistributedLock abpDistributedLock,
        IDistributedEventBus distributedEventBus,
        AgentServiceDataSeeder dataSeeder
    ) : base(
        AgentServiceDbContext.DatabaseName,
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