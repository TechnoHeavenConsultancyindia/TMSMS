using Volo.Abp.DependencyInjection;

namespace TMSMS.VisaService.Data;

public class VisaServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<VisaServiceDataSeeder> _logger;

    public VisaServiceDataSeeder(
        ILogger<VisaServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}