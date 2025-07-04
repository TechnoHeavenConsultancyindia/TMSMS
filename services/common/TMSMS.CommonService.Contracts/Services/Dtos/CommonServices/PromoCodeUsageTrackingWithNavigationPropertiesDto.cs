using TMSMS.CommonService.CommonServices;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeUsageTrackingWithNavigationPropertiesDtoBase
    {
        public PromoCodeUsageTrackingDto PromoCodeUsageTracking { get; set; } = null!;

        public PromoCodeMasterDto PromoCodeMaster { get; set; } = null!;

    }
}