using Volo.Abp.DependencyInjection;

namespace TMSMS.RestaurantService.Data;

public class RestaurantServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<RestaurantServiceDataSeeder> _logger;

    public RestaurantServiceDataSeeder(
        ILogger<RestaurantServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}