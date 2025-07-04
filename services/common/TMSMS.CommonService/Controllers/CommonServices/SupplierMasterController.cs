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
    [ControllerName("SupplierMaster")]
    [Route("api/common/supplier-masters")]

    public abstract class SupplierMasterControllerBase : AbpController
    {
        protected ISupplierMastersAppService _supplierMastersAppService;

        public SupplierMasterControllerBase(ISupplierMastersAppService supplierMastersAppService)
        {
            _supplierMastersAppService = supplierMastersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SupplierMasterWithNavigationPropertiesDto>> GetListAsync(GetSupplierMastersInput input)
        {
            return _supplierMastersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<SupplierMasterWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return _supplierMastersAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SupplierMasterDto> GetAsync(int id)
        {
            return _supplierMastersAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public virtual Task<PagedResultDto<LookupDto<int>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _supplierMastersAppService.GetCountryLookupAsync(input);
        }

        [HttpGet]
        [Route("supplier-service-type-lookup")]
        public virtual Task<PagedResultDto<LookupDto<int>>> GetSupplierServiceTypeLookupAsync(LookupRequestDto input)
        {
            return _supplierMastersAppService.GetSupplierServiceTypeLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<SupplierMasterDto> CreateAsync(SupplierMasterCreateDto input)
        {
            return _supplierMastersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SupplierMasterDto> UpdateAsync(int id, SupplierMasterUpdateDto input)
        {
            return _supplierMastersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _supplierMastersAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SupplierMasterExcelDownloadDto input)
        {
            return _supplierMastersAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _supplierMastersAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> suppliermasterIds)
        {
            return _supplierMastersAppService.DeleteByIdsAsync(suppliermasterIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetSupplierMastersInput input)
        {
            return _supplierMastersAppService.DeleteAllAsync(input);
        }
    }
}