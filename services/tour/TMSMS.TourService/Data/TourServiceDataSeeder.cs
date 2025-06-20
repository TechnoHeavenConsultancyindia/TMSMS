using Volo.Abp.DependencyInjection;

namespace TMSMS.TourService.Data;

public class TourServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<TourServiceDataSeeder> _logger;

    public TourServiceDataSeeder(
        ILogger<TourServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}