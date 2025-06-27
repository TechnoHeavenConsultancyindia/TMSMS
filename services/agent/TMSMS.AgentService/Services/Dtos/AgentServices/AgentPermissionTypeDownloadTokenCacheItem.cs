using System;

namespace TMSMS.AgentService.AgentServices;

public abstract class AgentPermissionTypeDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}