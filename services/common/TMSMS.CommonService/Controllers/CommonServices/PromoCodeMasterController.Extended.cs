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
    [ControllerName("PromoCodeMaster")]
    [Route("api/common/promo-code-masters")]

    public class PromoCodeMasterController : PromoCodeMasterControllerBase, IPromoCodeMastersAppService
    {
        public PromoCodeMasterController(IPromoCodeMastersAppService promoCodeMastersAppService) : base(promoCodeMastersAppService)
        {
        }
    }
}