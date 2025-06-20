using TMSMS.TourService.Localization;
using Volo.Abp.Application.Services;

namespace TMSMS.TourService;

public abstract class TourAppService : ApplicationService
{
    protected TourAppService()
    {
        LocalizationResource = typeof(TourServiceResource);
        ObjectMapperContext = typeof(TMSMSTourServiceModule);
    }
}