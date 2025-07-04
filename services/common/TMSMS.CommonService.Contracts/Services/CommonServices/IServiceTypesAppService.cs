using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IServiceTypesAppService : IApplicationService
    {

        Task<PagedResultDto<ServiceTypeDto>> GetListAsync(GetServiceTypesInput input);

        Task<ServiceTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<ServiceTypeDto> CreateAsync(ServiceTypeCreateDto input);

        Task<ServiceTypeDto> UpdateAsync(int id, ServiceTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ServiceTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> servicetypeIds);

        Task DeleteAllAsync(GetServiceTypesInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}