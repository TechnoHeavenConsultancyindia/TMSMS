namespace TMSMS.AgentService.AgentServices
{
    public static class AgentFinanceDetailConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AgentFinanceDetail." : string.Empty);
        }

        public const int CreditLimitCurrencyMaxLength = 10;
        public const int DisplayCurrencyMaxLength = 10;
    }
}