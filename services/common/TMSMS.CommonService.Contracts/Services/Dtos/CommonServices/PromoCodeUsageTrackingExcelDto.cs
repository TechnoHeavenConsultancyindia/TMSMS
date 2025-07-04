using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeUsageTrackingExcelDtoBase
    {
        public int UserID { get; set; }
        public int BookingID { get; set; }
        public DateTime UsageDate { get; set; }
    }
}