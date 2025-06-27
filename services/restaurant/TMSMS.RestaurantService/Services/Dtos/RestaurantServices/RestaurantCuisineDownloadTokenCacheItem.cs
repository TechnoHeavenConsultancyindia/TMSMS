using System;

namespace TMSMS.RestaurantService.RestaurantServices;

public abstract class RestaurantCuisineDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}