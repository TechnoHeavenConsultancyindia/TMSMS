using System;

namespace TMSMS.AgentService.AgentServices;

public abstract class AgentVoucherTypeDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}