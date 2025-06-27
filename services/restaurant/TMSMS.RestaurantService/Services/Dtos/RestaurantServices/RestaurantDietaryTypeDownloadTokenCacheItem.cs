using System;

namespace TMSMS.RestaurantService.RestaurantServices;

public abstract class RestaurantDietaryTypeDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}