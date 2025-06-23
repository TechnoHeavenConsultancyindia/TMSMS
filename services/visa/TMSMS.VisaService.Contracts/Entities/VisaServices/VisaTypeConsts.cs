namespace TMSMS.VisaService.VisaServices
{
    public static class VisaTypeConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "VisaType." : string.Empty);
        }

        public const int NameMaxLength = 100;
        public const int SubCategoryMaxLength = 100;
    }
}