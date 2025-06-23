using System;

namespace TMSMS.RestaurantService.RestaurantServices;

public abstract class RestaurantTagDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}