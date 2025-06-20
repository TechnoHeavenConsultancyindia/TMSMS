using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace TMSMS.AdministrationService.HealthChecks;

public class AdministrationServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly IPermissionGrantRepository _permissionGrantRepository;

    public AdministrationServiceDatabaseCheck(IPermissionGrantRepository permissionGrantRepository)
    {
        _permissionGrantRepository = permissionGrantRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _permissionGrantRepository.GetCountAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}

