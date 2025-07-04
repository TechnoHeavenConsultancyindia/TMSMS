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
    public partial interface IPromoCodeUsageTrackingsAppService : IApplicationService
    {

        Task<PagedResultDto<PromoCodeUsageTrackingWithNavigationPropertiesDto>> GetListAsync(GetPromoCodeUsageTrackingsInput input);

        Task<PromoCodeUsageTrackingWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id);

        Task<PromoCodeUsageTrackingDto> GetAsync(int id);

        Task<PagedResultDto<LookupDto<int>>> GetPromoCodeMasterLookupAsync(LookupRequestDto input);

        Task DeleteAsync(int id);

        Task<PromoCodeUsageTrackingDto> CreateAsync(PromoCodeUsageTrackingCreateDto input);

        Task<PromoCodeUsageTrackingDto> UpdateAsync(int id, PromoCodeUsageTrackingUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(PromoCodeUsageTrackingExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> promocodeusagetrackingIds);

        Task DeleteAllAsync(GetPromoCodeUsageTrackingsInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}