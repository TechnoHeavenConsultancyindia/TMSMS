namespace TMSMS.CommonService.CommonServices
{
    public static class CountryConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Country." : string.Empty);
        }

    }
}