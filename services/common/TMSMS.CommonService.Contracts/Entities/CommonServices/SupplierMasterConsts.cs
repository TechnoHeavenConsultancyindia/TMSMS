namespace TMSMS.CommonService.CommonServices
{
    public static class SupplierMasterConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SupplierMaster." : string.Empty);
        }

        public const int NameMaxLength = 150;
        public const int ContactNameMaxLength = 150;
        public const int ContactEmailMaxLength = 150;
        public const int DialCodeMaxLength = 10;
        public const int ContactPhoneMaxLength = 50;
    }
}