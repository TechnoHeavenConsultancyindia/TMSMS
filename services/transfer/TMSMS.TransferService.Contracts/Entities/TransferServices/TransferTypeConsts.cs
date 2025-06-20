namespace TMSMS.TransferService.TransferServices
{
    public static class TransferTypeConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TransferType." : string.Empty);
        }

        public const int NameMaxLength = 255;
    }
}