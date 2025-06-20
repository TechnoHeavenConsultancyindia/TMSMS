using System;

namespace TMSMS.TransferService.TransferServices;

public abstract class TransferTypeDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}