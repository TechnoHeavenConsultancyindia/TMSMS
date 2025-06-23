using System;

namespace TMSMS.AgentService.AgentServices;

public abstract class AgentFinanceDetailDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}