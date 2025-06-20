using Volo.Abp.DependencyInjection;

namespace TMSMS.AgentService.Data;

public class AgentServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<AgentServiceDataSeeder> _logger;

    public AgentServiceDataSeeder(
        ILogger<AgentServiceDataSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(Guid? tenantId = null)
    {
        _logger.LogInformation("Seeding data...");
        
        //...
    }
}