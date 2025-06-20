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
    [ControllerName("City")]
    [Route("api/common/cities")]

    public abstract class CityControllerBase : AbpController
    {
        protected ICitiesAppService _citiesAppService;

        public CityControllerBase(ICitiesAppService citiesAppService)
        {
            _citiesAppService = citiesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CityDto>> GetListAsync(GetCitiesInput input)
        {
            return _citiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CityDto> GetAsync(int id)
        {
            return _citiesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CityDto> CreateAsync(CityCreateDto input)
        {
            return _citiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CityDto> UpdateAsync(int id, CityUpdateDto input)
        {
            return _citiesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _citiesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CityExcelDownloadDto input)
        {
            return _citiesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _citiesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> cityIds)
        {
            return _citiesAppService.DeleteByIdsAsync(cityIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetCitiesInput input)
        {
            return _citiesAppService.DeleteAllAsync(input);
        }
    }
}