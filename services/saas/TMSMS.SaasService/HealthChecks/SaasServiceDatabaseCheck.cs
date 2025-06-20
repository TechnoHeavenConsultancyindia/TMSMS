using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Saas.Tenants;

namespace TMSMS.SaasService.HealthChecks;

public class SaasServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly ITenantRepository _tenantRepository;

    public SaasServiceDatabaseCheck(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _tenantRepository.GetCountAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}

