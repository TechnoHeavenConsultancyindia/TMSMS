namespace TMSMS.CommonService.CommonServices
{
    public static class CityConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "City." : string.Empty);
        }

    }
}