using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.CommonService.CommonServices;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("PromoCodeUsageTracking")]
    [Route("api/common/promo-code-usage-trackings")]

    public class PromoCodeUsageTrackingController : PromoCodeUsageTrackingControllerBase, IPromoCodeUsageTrackingsAppService
    {
        public PromoCodeUsageTrackingController(IPromoCodeUsageTrackingsAppService promoCodeUsageTrackingsAppService) : base(promoCodeUsageTrackingsAppService)
        {
        }
    }
}