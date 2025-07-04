using Volo.Abp.Reflection;

namespace TMSMS.CommonService.Permissions;

public class CommonServicePermissions
{
    public const string GroupName = "CommonService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CommonServicePermissions));
    }

    public static class Countries
    {
        public const string Default = GroupName + ".Countries";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class Cities
    {
        public const string Default = GroupName + ".Cities";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class Provinces
    {
        public const string Default = GroupName + ".Provinces";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class Regions
    {
        public const string Default = GroupName + ".Regions";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class WeekDays
    {
        public const string Default = GroupName + ".WeekDays";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static class PromoCodeMasters
    {
        public const string Default = GroupName + ".PromoCodeMasters";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}