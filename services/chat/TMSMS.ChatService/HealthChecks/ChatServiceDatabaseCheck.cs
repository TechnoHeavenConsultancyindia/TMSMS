using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Chat.Conversations;

namespace TMSMS.ChatService.HealthChecks;

public class ChatServiceDatabaseCheck : IHealthCheck, ITransientDependency
{
    private readonly IRepository<Conversation> _conversationRepository;

    public ChatServiceDatabaseCheck(IRepository<Conversation> conversationRepository)
    {
        _conversationRepository = conversationRepository;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var dbConnectionCancellationTokenProvider = new CancellationTokenSource();
            dbConnectionCancellationTokenProvider.CancelAfter(TimeSpan.FromSeconds(4));
            await _conversationRepository.FirstOrDefaultAsync(cancellationToken: dbConnectionCancellationTokenProvider.Token);
            
            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}
