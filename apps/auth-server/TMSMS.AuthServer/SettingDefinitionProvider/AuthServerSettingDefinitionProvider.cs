using Volo.Abp.Identity.Settings;
using Volo.Abp.Settings;
using Volo.Saas;

namespace TMSMS.AuthServer;

public class AuthServerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        // Change password policy
        var requireNonAlphanumeric = context.GetOrNull(IdentitySettingNames.Password.RequireNonAlphanumeric);
        if (requireNonAlphanumeric != null)
        {
            requireNonAlphanumeric.DefaultValue = false.ToString();
        }

        var requireLowercase = context.GetOrNull(IdentitySettingNames.Password.RequireLowercase);
        if (requireLowercase != null)
        {
            requireLowercase.DefaultValue = false.ToString();
        }

        var requireUppercase = context.GetOrNull(IdentitySettingNames.Password.RequireUppercase);
        if (requireUppercase != null)
        {
            requireUppercase.DefaultValue = false.ToString();
        }

        var requireDigit = context.GetOrNull(IdentitySettingNames.Password.RequireDigit);
        if (requireDigit != null)
        {
            requireDigit.DefaultValue = false.ToString();
        }

        // Disable tenant based connection string management
        var enableTenantBasedConnectionStringManagement = context.GetOrNull(SaasSettingNames.EnableTenantBasedConnectionStringManagement);
        if (enableTenantBasedConnectionStringManagement != null)
        {
            enableTenantBasedConnectionStringManagement.DefaultValue = false.ToString();
        }
    }
}
