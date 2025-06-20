using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.FileManagement.Files;

namespace TMSMS.FileManagementService.HealthChecks;

public class FileManagementServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly IRepository<FileDescriptor> _fileDescriptorRepository;

    public FileManagementServiceDatabaseCheck(IRepository<FileDescriptor> fileDescriptorRepository)
    {
        _fileDescriptorRepository = fileDescriptorRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _fileDescriptorRepository.FirstOrDefaultAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}

