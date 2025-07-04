using TMSMS.CommonService.CommonServices;

using System;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeUsageTrackingWithNavigationPropertiesBase
    {
        public PromoCodeUsageTracking PromoCodeUsageTracking { get; set; } = null!;

        public PromoCodeMaster PromoCodeMaster { get; set; } = null!;
        

        
    }
}