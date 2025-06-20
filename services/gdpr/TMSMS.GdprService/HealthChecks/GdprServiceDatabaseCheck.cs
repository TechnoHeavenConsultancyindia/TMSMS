using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Gdpr;

namespace TMSMS.GdprService.HealthChecks;

public class GdprServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly IRepository<GdprRequest> _gdprRequestRepository;

    public GdprServiceDatabaseCheck(IRepository<GdprRequest> gdprRequestRepository)
    {
        _gdprRequestRepository = gdprRequestRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _gdprRequestRepository.FirstOrDefaultAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}
