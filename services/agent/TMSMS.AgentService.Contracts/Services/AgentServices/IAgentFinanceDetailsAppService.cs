using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.AgentService.Shared;

namespace TMSMS.AgentService.AgentServices
{
    public partial interface IAgentFinanceDetailsAppService : IApplicationService
    {

        Task<PagedResultDto<AgentFinanceDetailDto>> GetListAsync(GetAgentFinanceDetailsInput input);

        Task<AgentFinanceDetailDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<AgentFinanceDetailDto> CreateAsync(AgentFinanceDetailCreateDto input);

        Task<AgentFinanceDetailDto> UpdateAsync(int id, AgentFinanceDetailUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentFinanceDetailExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> agentfinancedetailIds);

        Task DeleteAllAsync(GetAgentFinanceDetailsInput input);
        Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}