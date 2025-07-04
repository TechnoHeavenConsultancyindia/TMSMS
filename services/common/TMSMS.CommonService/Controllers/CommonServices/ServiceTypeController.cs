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
    [ControllerName("ServiceType")]
    [Route("api/common/service-types")]

    public abstract class ServiceTypeControllerBase : AbpController
    {
        protected IServiceTypesAppService _serviceTypesAppService;

        public ServiceTypeControllerBase(IServiceTypesAppService serviceTypesAppService)
        {
            _serviceTypesAppService = serviceTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ServiceTypeDto>> GetListAsync(GetServiceTypesInput input)
        {
            return _serviceTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ServiceTypeDto> GetAsync(int id)
        {
            return _serviceTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ServiceTypeDto> CreateAsync(ServiceTypeCreateDto input)
        {
            return _serviceTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ServiceTypeDto> UpdateAsync(int id, ServiceTypeUpdateDto input)
        {
            return _serviceTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _serviceTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ServiceTypeExcelDownloadDto input)
        {
            return _serviceTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _serviceTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> servicetypeIds)
        {
            return _serviceTypesAppService.DeleteByIdsAsync(servicetypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetServiceTypesInput input)
        {
            return _serviceTypesAppService.DeleteAllAsync(input);
        }
    }
}