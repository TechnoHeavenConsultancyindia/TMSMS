using Volo.Abp.DependencyInjection;

namespace TMSMS.CommonService.Data;

public class CommonServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<CommonServiceDataSeeder> _logger;

    public CommonServiceDataSeeder(
        ILogger<CommonServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}