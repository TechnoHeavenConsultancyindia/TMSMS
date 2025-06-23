using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.AgentService.Shared;

namespace TMSMS.AgentService.AgentServices
{
    public partial interface IAgentPermissionTypesAppService : IApplicationService
    {

        Task<PagedResultDto<AgentPermissionTypeDto>> GetListAsync(GetAgentPermissionTypesInput input);

        Task<AgentPermissionTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<AgentPermissionTypeDto> CreateAsync(AgentPermissionTypeCreateDto input);

        Task<AgentPermissionTypeDto> UpdateAsync(int id, AgentPermissionTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentPermissionTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> agentpermissiontypeIds);

        Task DeleteAllAsync(GetAgentPermissionTypesInput input);
        Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}