using Volo.Abp.Reflection;

namespace TMSMS.RestaurantService.Permissions;

public class RestaurantServicePermissions
{
    public const string GroupName = "RestaurantService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(RestaurantServicePermissions));
    }

    public static class RestaurantTypes
    {
        public const string Default = GroupName + ".RestaurantTypes";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class RestaurantTags
    {
        public const string Default = GroupName + ".RestaurantTags";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}