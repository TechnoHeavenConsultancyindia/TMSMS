using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.AgentService.Shared;

namespace TMSMS.AgentService.AgentServices
{
    public partial interface IAgentVoucherTypesAppService : IApplicationService
    {

        Task<PagedResultDto<AgentVoucherTypeDto>> GetListAsync(GetAgentVoucherTypesInput input);

        Task<AgentVoucherTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<AgentVoucherTypeDto> CreateAsync(AgentVoucherTypeCreateDto input);

        Task<AgentVoucherTypeDto> UpdateAsync(int id, AgentVoucherTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentVoucherTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> agentvouchertypeIds);

        Task DeleteAllAsync(GetAgentVoucherTypesInput input);
        Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}