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
    [ControllerName("SupplierServiceType")]
    [Route("api/common/supplier-service-types")]

    public abstract class SupplierServiceTypeControllerBase : AbpController
    {
        protected ISupplierServiceTypesAppService _supplierServiceTypesAppService;

        public SupplierServiceTypeControllerBase(ISupplierServiceTypesAppService supplierServiceTypesAppService)
        {
            _supplierServiceTypesAppService = supplierServiceTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SupplierServiceTypeDto>> GetListAsync(GetSupplierServiceTypesInput input)
        {
            return _supplierServiceTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SupplierServiceTypeDto> GetAsync(int id)
        {
            return _supplierServiceTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SupplierServiceTypeDto> CreateAsync(SupplierServiceTypeCreateDto input)
        {
            return _supplierServiceTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SupplierServiceTypeDto> UpdateAsync(int id, SupplierServiceTypeUpdateDto input)
        {
            return _supplierServiceTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _supplierServiceTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SupplierServiceTypeExcelDownloadDto input)
        {
            return _supplierServiceTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _supplierServiceTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> supplierservicetypeIds)
        {
            return _supplierServiceTypesAppService.DeleteByIdsAsync(supplierservicetypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetSupplierServiceTypesInput input)
        {
            return _supplierServiceTypesAppService.DeleteAllAsync(input);
        }
    }
}