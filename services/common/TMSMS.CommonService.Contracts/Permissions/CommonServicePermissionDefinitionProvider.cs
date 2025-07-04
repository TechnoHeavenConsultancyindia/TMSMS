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

        var weekDayPermission = myGroup.AddPermission(CommonServicePermissions.WeekDays.Default, L("Permission:WeekDays"));
        weekDayPermission.AddChild(CommonServicePermissions.WeekDays.Create, L("Permission:Create"));
        weekDayPermission.AddChild(CommonServicePermissions.WeekDays.Edit, L("Permission:Edit"));
        weekDayPermission.AddChild(CommonServicePermissions.WeekDays.Delete, L("Permission:Delete"));

        var promoCodeMasterPermission = myGroup.AddPermission(CommonServicePermissions.PromoCodeMasters.Default, L("Permission:PromoCodeMasters"));
        promoCodeMasterPermission.AddChild(CommonServicePermissions.PromoCodeMasters.Create, L("Permission:Create"));
        promoCodeMasterPermission.AddChild(CommonServicePermissions.PromoCodeMasters.Edit, L("Permission:Edit"));
        promoCodeMasterPermission.AddChild(CommonServicePermissions.PromoCodeMasters.Delete, L("Permission:Delete"));

        var promoCodeUsageTrackingPermission = myGroup.AddPermission(CommonServicePermissions.PromoCodeUsageTrackings.Default, L("Permission:PromoCodeUsageTrackings"));
        promoCodeUsageTrackingPermission.AddChild(CommonServicePermissions.PromoCodeUsageTrackings.Create, L("Permission:Create"));
        promoCodeUsageTrackingPermission.AddChild(CommonServicePermissions.PromoCodeUsageTrackings.Edit, L("Permission:Edit"));
        promoCodeUsageTrackingPermission.AddChild(CommonServicePermissions.PromoCodeUsageTrackings.Delete, L("Permission:Delete"));

        var supplierServiceTypePermission = myGroup.AddPermission(CommonServicePermissions.SupplierServiceTypes.Default, L("Permission:SupplierServiceTypes"));
        supplierServiceTypePermission.AddChild(CommonServicePermissions.SupplierServiceTypes.Create, L("Permission:Create"));
        supplierServiceTypePermission.AddChild(CommonServicePermissions.SupplierServiceTypes.Edit, L("Permission:Edit"));
        supplierServiceTypePermission.AddChild(CommonServicePermissions.SupplierServiceTypes.Delete, L("Permission:Delete"));

        var supplierMasterPermission = myGroup.AddPermission(CommonServicePermissions.SupplierMasters.Default, L("Permission:SupplierMasters"));
        supplierMasterPermission.AddChild(CommonServicePermissions.SupplierMasters.Create, L("Permission:Create"));
        supplierMasterPermission.AddChild(CommonServicePermissions.SupplierMasters.Edit, L("Permission:Edit"));
        supplierMasterPermission.AddChild(CommonServicePermissions.SupplierMasters.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CommonServiceResource>(name);
    }
}