namespace TMSMS.CommonService.CommonServices
{
    public static class WeekDayConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "WeekDay." : string.Empty);
        }

        public const int NameMaxLength = 25;
        public const int DayAbbreviationMaxLength = 25;
    }
}