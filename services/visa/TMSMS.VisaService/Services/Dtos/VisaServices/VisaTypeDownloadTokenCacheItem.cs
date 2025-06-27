using System;

namespace TMSMS.VisaService.VisaServices;

public abstract class VisaTypeDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}