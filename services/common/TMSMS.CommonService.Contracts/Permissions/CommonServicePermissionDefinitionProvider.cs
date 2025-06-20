using TMSMS.CommonService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TMSMS.CommonService.Permissions;

public class CommonServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CommonServicePermissions.GroupName);

        var countryPermission = myGroup.AddPermission(CommonServicePermissions.Countries.Default, L("Permission:Countries"));
        countryPermission.AddChild(CommonServicePermissions.Countries.Create, L("Permission:Create"));
        countryPermission.AddChild(CommonServicePermissions.Countries.Edit, L("Permission:Edit"));
        countryPermission.AddChild(CommonServicePermissions.Countries.Delete, L("Permission:Delete"));

        var cityPermission = myGroup.AddPermission(CommonServicePermissions.Cities.Default, L("Permission:Cities"));
        cityPermission.AddChild(CommonServicePermissions.Cities.Create, L("Permission:Create"));
        cityPermission.AddChild(CommonServicePermissions.Cities.Edit, L("Permission:Edit"));
        cityPermission.AddChild(CommonServicePermissions.Cities.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CommonServiceResource>(name);
    }
}