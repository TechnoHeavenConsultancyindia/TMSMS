using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.AuditLogging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.AuditLoggingService.HealthChecks;

public class AuditLoggingServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly IRepository<AuditLog> _auditLogRepository;

    public AuditLoggingServiceDatabaseCheck(IRepository<AuditLog> auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _auditLogRepository.FirstOrDefaultAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}
