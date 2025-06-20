using TMSMS.RestaurantService.Localization;
using Volo.Abp.Application.Services;

namespace TMSMS.RestaurantService;

public abstract class RestaurantAppService : ApplicationService
{
    protected RestaurantAppService()
    {
        LocalizationResource = typeof(RestaurantServiceResource);
        ObjectMapperContext = typeof(TMSMSRestaurantServiceModule);
    }
}