using Volo.Abp.Reflection;

namespace TMSMS.VisaService.Permissions;

public class VisaServicePermissions
{
    public const string GroupName = "VisaService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(VisaServicePermissions));
    }

    public static class VisaTermCategories
    {
        public const string Default = GroupName + ".VisaTermCategories";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}