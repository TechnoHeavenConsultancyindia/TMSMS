using TMSMS.TransferService.Localization;
using Volo.Abp.Application.Services;

namespace TMSMS.TransferService;

public abstract class TransferAppService : ApplicationService
{
    protected TransferAppService()
    {
        LocalizationResource = typeof(TransferServiceResource);
        ObjectMapperContext = typeof(TMSMSTransferServiceModule);
    }
}