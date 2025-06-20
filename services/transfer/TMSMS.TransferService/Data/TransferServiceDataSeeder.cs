using Volo.Abp.DependencyInjection;

namespace TMSMS.TransferService.Data;

public class TransferServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<TransferServiceDataSeeder> _logger;

    public TransferServiceDataSeeder(
        ILogger<TransferServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}