using TMSMS.AgentService.Localization;
using Volo.Abp.Application.Services;

namespace TMSMS.AgentService;

public abstract class AgentAppService : ApplicationService
{
    protected AgentAppService()
    {
        LocalizationResource = typeof(AgentServiceResource);
        ObjectMapperContext = typeof(TMSMSAgentServiceModule);
    }
}