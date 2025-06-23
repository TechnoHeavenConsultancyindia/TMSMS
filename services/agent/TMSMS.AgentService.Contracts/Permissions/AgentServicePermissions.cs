using Volo.Abp.Reflection;

namespace TMSMS.AgentService.Permissions;

public class AgentServicePermissions
{
    public const string GroupName = "AgentService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AgentServicePermissions));
    }

    public static class AgentGroupTypes
    {
        public const string Default = GroupName + ".AgentGroupTypes";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class AgentPermissionTypes
    {
        public const string Default = GroupName + ".AgentPermissionTypes";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class AgentVoucherTypes
    {
        public const string Default = GroupName + ".AgentVoucherTypes";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class AgentFinanceDetails
    {
        public const string Default = GroupName + ".AgentFinanceDetails";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}