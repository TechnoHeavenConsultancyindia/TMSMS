using Volo.Abp.DistributedLocking;
using Volo.Abp.EntityFrameworkCore.Migrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TMSMS.TransferService.Data;

public class TransferServiceRuntimeDatabaseMigrator : EfCoreRuntimeDatabaseMigratorBase<TransferServiceDbContext>
{
    private readonly TransferServiceDataSeeder _dataSeeder;

    public TransferServiceRuntimeDatabaseMigrator(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IAbpDistributedLock abpDistributedLock,
        IDistributedEventBus distributedEventBus,
        TransferServiceDataSeeder dataSeeder
    ) : base(
        TransferServiceDbContext.DatabaseName,
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