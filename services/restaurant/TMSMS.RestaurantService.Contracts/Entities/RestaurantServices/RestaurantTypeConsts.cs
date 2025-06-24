namespace TMSMS.RestaurantService.RestaurantServices
{
    public static class RestaurantTypeConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "RestaurantType." : string.Empty);
        }

        public const int NameMaxLength = 255;
        public const int DescriptionMaxLength = 1000;
    }
}