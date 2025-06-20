using Volo.Abp.Settings;
using Volo.Saas;

namespace TMSMS.SaasService.Data;

public class SaasServiceDisableTenantBasedConnectionStringManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        var enableTenantBasedConnectionStringManagement = context.GetOrNull(SaasSettingNames.EnableTenantBasedConnectionStringManagement);
        if (enableTenantBasedConnectionStringManagement != null)
        {
            enableTenantBasedConnectionStringManagement.DefaultValue = false.ToString();
        }
    }
}
