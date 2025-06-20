using Volo.Abp.Reflection;

namespace TMSMS.AgentService.Permissions;

public class AgentServicePermissions
{
    public const string GroupName = "AgentService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AgentServicePermissions));
    }
}