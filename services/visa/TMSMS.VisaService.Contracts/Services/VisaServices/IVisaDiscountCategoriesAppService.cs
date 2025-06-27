using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.VisaService.Shared;

namespace TMSMS.VisaService.VisaServices
{
    public partial interface IVisaDiscountCategoriesAppService : IApplicationService
    {

        Task<PagedResultDto<VisaDiscountCategoryDto>> GetListAsync(GetVisaDiscountCategoriesInput input);

        Task<VisaDiscountCategoryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<VisaDiscountCategoryDto> CreateAsync(VisaDiscountCategoryCreateDto input);

        Task<VisaDiscountCategoryDto> UpdateAsync(int id, VisaDiscountCategoryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaDiscountCategoryExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> visadiscountcategoryIds);

        Task DeleteAllAsync(GetVisaDiscountCategoriesInput input);
        Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}