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
    public partial interface ISupplierMastersAppService : IApplicationService
    {

        Task<PagedResultDto<SupplierMasterWithNavigationPropertiesDto>> GetListAsync(GetSupplierMastersInput input);

        Task<SupplierMasterWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id);

        Task<SupplierMasterDto> GetAsync(int id);

        Task<PagedResultDto<LookupDto<int>>> GetCountryLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<int>>> GetSupplierServiceTypeLookupAsync(LookupRequestDto input);

        Task DeleteAsync(int id);

        Task<SupplierMasterDto> CreateAsync(SupplierMasterCreateDto input);

        Task<SupplierMasterDto> UpdateAsync(int id, SupplierMasterUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SupplierMasterExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> suppliermasterIds);

        Task DeleteAllAsync(GetSupplierMastersInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}