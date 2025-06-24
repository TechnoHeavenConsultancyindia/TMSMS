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
    [ControllerName("Region")]
    [Route("api/common/regions")]

    public abstract class RegionControllerBase : AbpController
    {
        protected IRegionsAppService _regionsAppService;

        public RegionControllerBase(IRegionsAppService regionsAppService)
        {
            _regionsAppService = regionsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RegionDto>> GetListAsync(GetRegionsInput input)
        {
            return _regionsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RegionDto> GetAsync(int id)
        {
            return _regionsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<RegionDto> CreateAsync(RegionCreateDto input)
        {
            return _regionsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<RegionDto> UpdateAsync(int id, RegionUpdateDto input)
        {
            return _regionsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _regionsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(RegionExcelDownloadDto input)
        {
            return _regionsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _regionsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> regionIds)
        {
            return _regionsAppService.DeleteByIdsAsync(regionIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetRegionsInput input)
        {
            return _regionsAppService.DeleteAllAsync(input);
        }
    }
}