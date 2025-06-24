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
    [ControllerName("VisaDiscountCategory")]
    [Route("api/visa/visa-discount-categories")]

    public abstract class VisaDiscountCategoryControllerBase : AbpController
    {
        protected IVisaDiscountCategoriesAppService _visaDiscountCategoriesAppService;

        public VisaDiscountCategoryControllerBase(IVisaDiscountCategoriesAppService visaDiscountCategoriesAppService)
        {
            _visaDiscountCategoriesAppService = visaDiscountCategoriesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<VisaDiscountCategoryDto>> GetListAsync(GetVisaDiscountCategoriesInput input)
        {
            return _visaDiscountCategoriesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<VisaDiscountCategoryDto> GetAsync(int id)
        {
            return _visaDiscountCategoriesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<VisaDiscountCategoryDto> CreateAsync(VisaDiscountCategoryCreateDto input)
        {
            return _visaDiscountCategoriesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<VisaDiscountCategoryDto> UpdateAsync(int id, VisaDiscountCategoryUpdateDto input)
        {
            return _visaDiscountCategoriesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _visaDiscountCategoriesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaDiscountCategoryExcelDownloadDto input)
        {
            return _visaDiscountCategoriesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _visaDiscountCategoriesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> visadiscountcategoryIds)
        {
            return _visaDiscountCategoriesAppService.DeleteByIdsAsync(visadiscountcategoryIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetVisaDiscountCategoriesInput input)
        {
            return _visaDiscountCategoriesAppService.DeleteAllAsync(input);
        }
    }
}