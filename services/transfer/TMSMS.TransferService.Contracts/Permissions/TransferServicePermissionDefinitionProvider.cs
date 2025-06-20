using TMSMS.TransferService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TMSMS.TransferService.Permissions;

public class TransferServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TransferServicePermissions.GroupName);

        var transferTypePermission = myGroup.AddPermission(TransferServicePermissions.TransferTypes.Default, L("Permission:TransferTypes"));
        transferTypePermission.AddChild(TransferServicePermissions.TransferTypes.Create, L("Permission:Create"));
        transferTypePermission.AddChild(TransferServicePermissions.TransferTypes.Edit, L("Permission:Edit"));
        transferTypePermission.AddChild(TransferServicePermissions.TransferTypes.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TransferServiceResource>(name);
    }
}