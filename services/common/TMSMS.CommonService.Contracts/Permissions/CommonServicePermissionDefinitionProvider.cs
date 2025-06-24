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

        var provincePermission = myGroup.AddPermission(CommonServicePermissions.Provinces.Default, L("Permission:Provinces"));
        provincePermission.AddChild(CommonServicePermissions.Provinces.Create, L("Permission:Create"));
        provincePermission.AddChild(CommonServicePermissions.Provinces.Edit, L("Permission:Edit"));
        provincePermission.AddChild(CommonServicePermissions.Provinces.Delete, L("Permission:Delete"));

        var regionPermission = myGroup.AddPermission(CommonServicePermissions.Regions.Default, L("Permission:Regions"));
        regionPermission.AddChild(CommonServicePermissions.Regions.Create, L("Permission:Create"));
        regionPermission.AddChild(CommonServicePermissions.Regions.Edit, L("Permission:Edit"));
        regionPermission.AddChild(CommonServicePermissions.Regions.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CommonServiceResource>(name);
    }
}