namespace TMSMS.VisaService.VisaServices
{
    public static class VisaDiscountCategoryConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "VisaDiscountCategory." : string.Empty);
        }

        public const int NameMaxLength = 150;
        public const int DescriptionMaxLength = 500;
    }
}