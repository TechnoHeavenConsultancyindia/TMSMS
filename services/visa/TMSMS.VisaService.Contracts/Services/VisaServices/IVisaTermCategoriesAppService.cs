using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.VisaService.Shared;

namespace TMSMS.VisaService.VisaServices
{
    public partial interface IVisaTermCategoriesAppService : IApplicationService
    {

        Task<PagedResultDto<VisaTermCategoryDto>> GetListAsync(GetVisaTermCategoriesInput input);

        Task<VisaTermCategoryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<VisaTermCategoryDto> CreateAsync(VisaTermCategoryCreateDto input);

        Task<VisaTermCategoryDto> UpdateAsync(int id, VisaTermCategoryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaTermCategoryExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> visatermcategoryIds);

        Task DeleteAllAsync(GetVisaTermCategoriesInput input);
        Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}