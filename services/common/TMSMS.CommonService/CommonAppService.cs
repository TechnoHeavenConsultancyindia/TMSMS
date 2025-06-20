using TMSMS.CommonService.Localization;
using Volo.Abp.Application.Services;

namespace TMSMS.CommonService;

public abstract class CommonAppService : ApplicationService
{
    protected CommonAppService()
    {
        LocalizationResource = typeof(CommonServiceResource);
        ObjectMapperContext = typeof(TMSMSCommonServiceModule);
    }
}