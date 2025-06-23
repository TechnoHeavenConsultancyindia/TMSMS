using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.AgentService.Shared;

namespace TMSMS.AgentService.AgentServices
{
    public partial interface IAgentGroupTypesAppService : IApplicationService
    {

        Task<PagedResultDto<AgentGroupTypeDto>> GetListAsync(GetAgentGroupTypesInput input);

        Task<AgentGroupTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<AgentGroupTypeDto> CreateAsync(AgentGroupTypeCreateDto input);

        Task<AgentGroupTypeDto> UpdateAsync(int id, AgentGroupTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentGroupTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> agentgrouptypeIds);

        Task DeleteAllAsync(GetAgentGroupTypesInput input);
        Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}