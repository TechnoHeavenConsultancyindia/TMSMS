using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.LanguageManagement;

namespace TMSMS.LanguageService.HealthChecks;

public class LanguageServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageServiceDatabaseCheck(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _languageRepository.GetCountAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}

