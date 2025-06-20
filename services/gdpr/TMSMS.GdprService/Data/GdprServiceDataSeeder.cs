using Volo.Abp.DependencyInjection;

namespace TMSMS.GdprService.Data;

public class GdprServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<GdprServiceDataSeeder> _logger;

    public GdprServiceDataSeeder(
        ILogger<GdprServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}