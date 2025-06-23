using System;

namespace TMSMS.RestaurantService.RestaurantServices;

public abstract class RestaurantTypeDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}