using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IProvincesAppService : IApplicationService
    {

        Task<PagedResultDto<ProvinceDto>> GetListAsync(GetProvincesInput input);

        Task<ProvinceDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<ProvinceDto> CreateAsync(ProvinceCreateDto input);

        Task<ProvinceDto> UpdateAsync(int id, ProvinceUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ProvinceExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> provinceIds);

        Task DeleteAllAsync(GetProvincesInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}