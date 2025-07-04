namespace TMSMS.CommonService.CommonServices
{
    public static class PromoCodeMasterConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PromoCodeMaster." : string.Empty);
        }

        public const int NameMaxLength = 255;
        public const int PromoCodeMaxLength = 50;
        public const int ServiceTypeMaxLength = 100;
        public const int DiscountTypeMaxLength = 50;
        public const int CustomerTypeMaxLength = 50;
        public const int PaymentMethodMaxLength = 100;
        public const int UserGroupMaxLength = 100;
    }
}