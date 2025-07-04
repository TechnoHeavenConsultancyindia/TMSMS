namespace TMSMS.CommonService.CommonServices
{
    public static class ServiceTypeConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ServiceType." : string.Empty);
        }

        public const int NameMaxLength = 100;
    }
}