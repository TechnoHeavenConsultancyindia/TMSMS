namespace TMSMS.CommonService.CommonServices
{
    public static class PromoCodeUsageTrackingConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PromoCodeUsageTracking." : string.Empty);
        }

    }
}