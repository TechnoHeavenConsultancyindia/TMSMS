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
    [ControllerName("Province")]
    [Route("api/common/provinces")]

    public abstract class ProvinceControllerBase : AbpController
    {
        protected IProvincesAppService _provincesAppService;

        public ProvinceControllerBase(IProvincesAppService provincesAppService)
        {
            _provincesAppService = provincesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ProvinceDto>> GetListAsync(GetProvincesInput input)
        {
            return _provincesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ProvinceDto> GetAsync(int id)
        {
            return _provincesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ProvinceDto> CreateAsync(ProvinceCreateDto input)
        {
            return _provincesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ProvinceDto> UpdateAsync(int id, ProvinceUpdateDto input)
        {
            return _provincesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _provincesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ProvinceExcelDownloadDto input)
        {
            return _provincesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _provincesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> provinceIds)
        {
            return _provincesAppService.DeleteByIdsAsync(provinceIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetProvincesInput input)
        {
            return _provincesAppService.DeleteAllAsync(input);
        }
    }
}