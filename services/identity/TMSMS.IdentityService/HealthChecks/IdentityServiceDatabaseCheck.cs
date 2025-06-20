using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace TMSMS.IdentityService.HealthChecks;

public class IdentityServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly IIdentityUserRepository _identityUserRepository;

    public IdentityServiceDatabaseCheck(IIdentityUserRepository identityUserRepository)
    {
        _identityUserRepository = identityUserRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _identityUserRepository.GetCountAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}
