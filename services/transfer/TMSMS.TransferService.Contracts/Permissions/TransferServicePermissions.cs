using Volo.Abp.Reflection;

namespace TMSMS.TransferService.Permissions;

public class TransferServicePermissions
{
    public const string GroupName = "TransferService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TransferServicePermissions));
    }

    public static class TransferTypes
    {
        public const string Default = GroupName + ".TransferTypes";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}