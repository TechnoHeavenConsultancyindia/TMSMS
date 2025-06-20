using TMSMS.VisaService.Localization;
using Volo.Abp.Application.Services;

namespace TMSMS.VisaService;

public abstract class VisaAppService : ApplicationService
{
    protected VisaAppService()
    {
        LocalizationResource = typeof(VisaServiceResource);
        ObjectMapperContext = typeof(TMSMSVisaServiceModule);
    }
}