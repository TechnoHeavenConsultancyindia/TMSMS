using Volo.Abp.Reflection;

namespace TMSMS.TourService.Permissions;

public class TourServicePermissions
{
    public const string GroupName = "TourService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TourServicePermissions));
    }
}