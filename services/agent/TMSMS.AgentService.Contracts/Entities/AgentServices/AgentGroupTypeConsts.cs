namespace TMSMS.AgentService.AgentServices
{
    public static class AgentGroupTypeConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AgentGroupType." : string.Empty);
        }

        public const int NameMaxLength = 255;
        public const int DescriptionMaxLength = 500;
    }
}