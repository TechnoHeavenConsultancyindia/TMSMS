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
    [ControllerName("PromoCodeMaster")]
    [Route("api/common/promo-code-masters")]

    public abstract class PromoCodeMasterControllerBase : AbpController
    {
        protected IPromoCodeMastersAppService _promoCodeMastersAppService;

        public PromoCodeMasterControllerBase(IPromoCodeMastersAppService promoCodeMastersAppService)
        {
            _promoCodeMastersAppService = promoCodeMastersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PromoCodeMasterWithNavigationPropertiesDto>> GetListAsync(GetPromoCodeMastersInput input)
        {
            return _promoCodeMastersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<PromoCodeMasterWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return _promoCodeMastersAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PromoCodeMasterDto> GetAsync(int id)
        {
            return _promoCodeMastersAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public virtual Task<PagedResultDto<LookupDto<int>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _promoCodeMastersAppService.GetCountryLookupAsync(input);
        }

        [HttpGet]
        [Route("city-lookup")]
        public virtual Task<PagedResultDto<LookupDto<int>>> GetCityLookupAsync(LookupRequestDto input)
        {
            return _promoCodeMastersAppService.GetCityLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<PromoCodeMasterDto> CreateAsync(PromoCodeMasterCreateDto input)
        {
            return _promoCodeMastersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PromoCodeMasterDto> UpdateAsync(int id, PromoCodeMasterUpdateDto input)
        {
            return _promoCodeMastersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _promoCodeMastersAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(PromoCodeMasterExcelDownloadDto input)
        {
            return _promoCodeMastersAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _promoCodeMastersAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> promocodemasterIds)
        {
            return _promoCodeMastersAppService.DeleteByIdsAsync(promocodemasterIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetPromoCodeMastersInput input)
        {
            return _promoCodeMastersAppService.DeleteAllAsync(input);
        }
    }
}