using Volo.Abp.Reflection;

namespace TMSMS.RestaurantService.Permissions;

public class RestaurantServicePermissions
{
    public const string GroupName = "RestaurantService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(RestaurantServicePermissions));
    }
}