using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface ICitiesAppService : IApplicationService
    {

        Task<PagedResultDto<CityDto>> GetListAsync(GetCitiesInput input);

        Task<CityDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<CityDto> CreateAsync(CityCreateDto input);

        Task<CityDto> UpdateAsync(int id, CityUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CityExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> cityIds);

        Task DeleteAllAsync(GetCitiesInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}