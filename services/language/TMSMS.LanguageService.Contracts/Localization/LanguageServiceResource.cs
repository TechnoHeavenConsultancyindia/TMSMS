using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Validation.Localization;

namespace TMSMS.LanguageService.Localization;
    
[LocalizationResourceName("LanguageService")]
[InheritResource(
    typeof(AbpValidationResource),
    typeof(AbpUiResource)
)]
public class LanguageServiceResource
{
        
}
