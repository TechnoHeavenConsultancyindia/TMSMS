using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.VisaService.VisaServices;
using Volo.Abp.Content;
using TMSMS.VisaService.Shared;

namespace TMSMS.VisaService.VisaServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("VisaType")]
    [Route("api/visa/visa-types")]

    public abstract class VisaTypeControllerBase : AbpController
    {
        protected IVisaTypesAppService _visaTypesAppService;

        public VisaTypeControllerBase(IVisaTypesAppService visaTypesAppService)
        {
            _visaTypesAppService = visaTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<VisaTypeDto>> GetListAsync(GetVisaTypesInput input)
        {
            return _visaTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<VisaTypeDto> GetAsync(int id)
        {
            return _visaTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<VisaTypeDto> CreateAsync(VisaTypeCreateDto input)
        {
            return _visaTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<VisaTypeDto> UpdateAsync(int id, VisaTypeUpdateDto input)
        {
            return _visaTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _visaTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaTypeExcelDownloadDto input)
        {
            return _visaTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _visaTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> visatypeIds)
        {
            return _visaTypesAppService.DeleteByIdsAsync(visatypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetVisaTypesInput input)
        {
            return _visaTypesAppService.DeleteAllAsync(input);
        }
    }
}