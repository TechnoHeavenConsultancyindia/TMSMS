using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.AgentService.AgentServices;
using Volo.Abp.Content;
using TMSMS.AgentService.Shared;

namespace TMSMS.AgentService.AgentServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("AgentPermissionType")]
    [Route("api/agent/agent-permission-types")]

    public abstract class AgentPermissionTypeControllerBase : AbpController
    {
        protected IAgentPermissionTypesAppService _agentPermissionTypesAppService;

        public AgentPermissionTypeControllerBase(IAgentPermissionTypesAppService agentPermissionTypesAppService)
        {
            _agentPermissionTypesAppService = agentPermissionTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AgentPermissionTypeDto>> GetListAsync(GetAgentPermissionTypesInput input)
        {
            return _agentPermissionTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AgentPermissionTypeDto> GetAsync(int id)
        {
            return _agentPermissionTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AgentPermissionTypeDto> CreateAsync(AgentPermissionTypeCreateDto input)
        {
            return _agentPermissionTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AgentPermissionTypeDto> UpdateAsync(int id, AgentPermissionTypeUpdateDto input)
        {
            return _agentPermissionTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _agentPermissionTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentPermissionTypeExcelDownloadDto input)
        {
            return _agentPermissionTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _agentPermissionTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> agentpermissiontypeIds)
        {
            return _agentPermissionTypesAppService.DeleteByIdsAsync(agentpermissiontypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetAgentPermissionTypesInput input)
        {
            return _agentPermissionTypesAppService.DeleteAllAsync(input);
        }
    }
}