using TMSMS.CommonService.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.CommonService.CommonServices;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("PromoCodeUsageTracking")]
    [Route("api/common/promo-code-usage-trackings")]

    public abstract class PromoCodeUsageTrackingControllerBase : AbpController
    {
        protected IPromoCodeUsageTrackingsAppService _promoCodeUsageTrackingsAppService;

        public PromoCodeUsageTrackingControllerBase(IPromoCodeUsageTrackingsAppService promoCodeUsageTrackingsAppService)
        {
            _promoCodeUsageTrackingsAppService = promoCodeUsageTrackingsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PromoCodeUsageTrackingWithNavigationPropertiesDto>> GetListAsync(GetPromoCodeUsageTrackingsInput input)
        {
            return _promoCodeUsageTrackingsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<PromoCodeUsageTrackingWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return _promoCodeUsageTrackingsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PromoCodeUsageTrackingDto> GetAsync(int id)
        {
            return _promoCodeUsageTrackingsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("promo-code-master-lookup")]
        public virtual Task<PagedResultDto<LookupDto<int>>> GetPromoCodeMasterLookupAsync(LookupRequestDto input)
        {
            return _promoCodeUsageTrackingsAppService.GetPromoCodeMasterLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<PromoCodeUsageTrackingDto> CreateAsync(PromoCodeUsageTrackingCreateDto input)
        {
            return _promoCodeUsageTrackingsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PromoCodeUsageTrackingDto> UpdateAsync(int id, PromoCodeUsageTrackingUpdateDto input)
        {
            return _promoCodeUsageTrackingsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _promoCodeUsageTrackingsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(PromoCodeUsageTrackingExcelDownloadDto input)
        {
            return _promoCodeUsageTrackingsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _promoCodeUsageTrackingsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> promocodeusagetrackingIds)
        {
            return _promoCodeUsageTrackingsAppService.DeleteByIdsAsync(promocodeusagetrackingIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetPromoCodeUsageTrackingsInput input)
        {
            return _promoCodeUsageTrackingsAppService.DeleteAllAsync(input);
        }
    }
}