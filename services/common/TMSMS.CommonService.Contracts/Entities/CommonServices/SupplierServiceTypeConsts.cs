namespace TMSMS.CommonService.CommonServices
{
    public static class SupplierServiceTypeConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SupplierServiceType." : string.Empty);
        }

        public const int NameMaxLength = 150;
        public const int DescriptionMaxLength = 255;
    }
}