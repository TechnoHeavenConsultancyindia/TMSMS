using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeUsageTrackingCreateDtoBase
    {
        public int UserID { get; set; }
        public int BookingID { get; set; }
        public DateTime UsageDate { get; set; }
        public int? PromoCodeMasterId { get; set; }
    }
}