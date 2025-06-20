using Volo.Abp.Reflection;

namespace TMSMS.VisaService.Permissions;

public class VisaServicePermissions
{
    public const string GroupName = "VisaService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(VisaServicePermissions));
    }
}