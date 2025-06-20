using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface ICountriesAppService : IApplicationService
    {

        Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input);

        Task<CountryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<CountryDto> CreateAsync(CountryCreateDto input);

        Task<CountryDto> UpdateAsync(int id, CountryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CountryExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> countryIds);

        Task DeleteAllAsync(GetCountriesInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}