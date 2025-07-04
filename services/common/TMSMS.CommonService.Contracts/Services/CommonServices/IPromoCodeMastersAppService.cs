using TMSMS.CommonService.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IPromoCodeMastersAppService : IApplicationService
    {

        Task<PagedResultDto<PromoCodeMasterWithNavigationPropertiesDto>> GetListAsync(GetPromoCodeMastersInput input);

        Task<PromoCodeMasterWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id);

        Task<PromoCodeMasterDto> GetAsync(int id);

        Task<PagedResultDto<LookupDto<int>>> GetCountryLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<int>>> GetCityLookupAsync(LookupRequestDto input);

        Task DeleteAsync(int id);

        Task<PromoCodeMasterDto> CreateAsync(PromoCodeMasterCreateDto input);

        Task<PromoCodeMasterDto> UpdateAsync(int id, PromoCodeMasterUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PromoCodeMasterExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> promocodemasterIds);

        Task DeleteAllAsync(GetPromoCodeMastersInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}