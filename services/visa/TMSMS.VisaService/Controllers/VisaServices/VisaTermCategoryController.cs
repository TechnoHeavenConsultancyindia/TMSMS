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
    [ControllerName("VisaTermCategory")]
    [Route("api/visa/visa-term-categories")]

    public abstract class VisaTermCategoryControllerBase : AbpController
    {
        protected IVisaTermCategoriesAppService _visaTermCategoriesAppService;

        public VisaTermCategoryControllerBase(IVisaTermCategoriesAppService visaTermCategoriesAppService)
        {
            _visaTermCategoriesAppService = visaTermCategoriesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<VisaTermCategoryDto>> GetListAsync(GetVisaTermCategoriesInput input)
        {
            return _visaTermCategoriesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<VisaTermCategoryDto> GetAsync(int id)
        {
            return _visaTermCategoriesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<VisaTermCategoryDto> CreateAsync(VisaTermCategoryCreateDto input)
        {
            return _visaTermCategoriesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<VisaTermCategoryDto> UpdateAsync(int id, VisaTermCategoryUpdateDto input)
        {
            return _visaTermCategoriesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _visaTermCategoriesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaTermCategoryExcelDownloadDto input)
        {
            return _visaTermCategoriesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _visaTermCategoriesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> visatermcategoryIds)
        {
            return _visaTermCategoriesAppService.DeleteByIdsAsync(visatermcategoryIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetVisaTermCategoriesInput input)
        {
            return _visaTermCategoriesAppService.DeleteAllAsync(input);
        }
    }
}