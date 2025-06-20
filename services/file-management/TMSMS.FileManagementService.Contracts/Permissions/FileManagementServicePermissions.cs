using Volo.Abp.Reflection;

namespace TMSMS.FileManagementService.Permissions;

public class FileManagementServicePermissions
{
    public const string GroupName = "FileManagementService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FileManagementServicePermissions));
    }
}