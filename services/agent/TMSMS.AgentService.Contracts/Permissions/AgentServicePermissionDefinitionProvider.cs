using TMSMS.AgentService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TMSMS.AgentService.Permissions;

public class AgentServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AgentServicePermissions.GroupName);

        var agentGroupTypePermission = myGroup.AddPermission(AgentServicePermissions.AgentGroupTypes.Default, L("Permission:AgentGroupTypes"));
        agentGroupTypePermission.AddChild(AgentServicePermissions.AgentGroupTypes.Create, L("Permission:Create"));
        agentGroupTypePermission.AddChild(AgentServicePermissions.AgentGroupTypes.Edit, L("Permission:Edit"));
        agentGroupTypePermission.AddChild(AgentServicePermissions.AgentGroupTypes.Delete, L("Permission:Delete"));

        var agentPermissionTypePermission = myGroup.AddPermission(AgentServicePermissions.AgentPermissionTypes.Default, L("Permission:AgentPermissionTypes"));
        agentPermissionTypePermission.AddChild(AgentServicePermissions.AgentPermissionTypes.Create, L("Permission:Create"));
        agentPermissionTypePermission.AddChild(AgentServicePermissions.AgentPermissionTypes.Edit, L("Permission:Edit"));
        agentPermissionTypePermission.AddChild(AgentServicePermissions.AgentPermissionTypes.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AgentServiceResource>(name);
    }
}