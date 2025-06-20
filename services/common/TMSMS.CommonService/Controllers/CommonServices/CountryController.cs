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
    [ControllerName("Country")]
    [Route("api/common/countries")]

    public abstract class CountryControllerBase : AbpController
    {
        protected ICountriesAppService _countriesAppService;

        public CountryControllerBase(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            return _countriesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CountryDto> GetAsync(int id)
        {
            return _countriesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CountryDto> CreateAsync(CountryCreateDto input)
        {
            return _countriesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CountryDto> UpdateAsync(int id, CountryUpdateDto input)
        {
            return _countriesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _countriesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CountryExcelDownloadDto input)
        {
            return _countriesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _countriesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> countryIds)
        {
            return _countriesAppService.DeleteByIdsAsync(countryIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetCountriesInput input)
        {
            return _countriesAppService.DeleteAllAsync(input);
        }
    }
}