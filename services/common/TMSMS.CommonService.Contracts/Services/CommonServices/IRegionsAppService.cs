using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IRegionsAppService : IApplicationService
    {

        Task<PagedResultDto<RegionDto>> GetListAsync(GetRegionsInput input);

        Task<RegionDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<RegionDto> CreateAsync(RegionCreateDto input);

        Task<RegionDto> UpdateAsync(int id, RegionUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(RegionExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> regionIds);

        Task DeleteAllAsync(GetRegionsInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}