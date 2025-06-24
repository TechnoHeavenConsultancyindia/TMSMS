using TMSMS.VisaService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TMSMS.VisaService.Permissions;

public class VisaServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VisaServicePermissions.GroupName);

        var visaTermCategoryPermission = myGroup.AddPermission(VisaServicePermissions.VisaTermCategories.Default, L("Permission:VisaTermCategories"));
        visaTermCategoryPermission.AddChild(VisaServicePermissions.VisaTermCategories.Create, L("Permission:Create"));
        visaTermCategoryPermission.AddChild(VisaServicePermissions.VisaTermCategories.Edit, L("Permission:Edit"));
        visaTermCategoryPermission.AddChild(VisaServicePermissions.VisaTermCategories.Delete, L("Permission:Delete"));

        var visaTypePermission = myGroup.AddPermission(VisaServicePermissions.VisaTypes.Default, L("Permission:VisaTypes"));
        visaTypePermission.AddChild(VisaServicePermissions.VisaTypes.Create, L("Permission:Create"));
        visaTypePermission.AddChild(VisaServicePermissions.VisaTypes.Edit, L("Permission:Edit"));
        visaTypePermission.AddChild(VisaServicePermissions.VisaTypes.Delete, L("Permission:Delete"));

        var visaDiscountCategoryPermission = myGroup.AddPermission(VisaServicePermissions.VisaDiscountCategories.Default, L("Permission:VisaDiscountCategories"));
        visaDiscountCategoryPermission.AddChild(VisaServicePermissions.VisaDiscountCategories.Create, L("Permission:Create"));
        visaDiscountCategoryPermission.AddChild(VisaServicePermissions.VisaDiscountCategories.Edit, L("Permission:Edit"));
        visaDiscountCategoryPermission.AddChild(VisaServicePermissions.VisaDiscountCategories.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VisaServiceResource>(name);
    }
}