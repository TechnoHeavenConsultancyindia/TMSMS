using Volo.Abp.Reflection;

namespace TMSMS.AdministrationService.Permissions;

public class AdministrationServicePermissions
{
    public const string GroupName = "AdministrationService";

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = DashboardGroup + ".Tenant";
    }
    
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdministrationServicePermissions));
    }
}