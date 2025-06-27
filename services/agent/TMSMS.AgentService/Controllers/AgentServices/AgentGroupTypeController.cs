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
    [ControllerName("AgentGroupType")]
    [Route("api/agent/agent-group-types")]

    public abstract class AgentGroupTypeControllerBase : AbpController
    {
        protected IAgentGroupTypesAppService _agentGroupTypesAppService;

        public AgentGroupTypeControllerBase(IAgentGroupTypesAppService agentGroupTypesAppService)
        {
            _agentGroupTypesAppService = agentGroupTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AgentGroupTypeDto>> GetListAsync(GetAgentGroupTypesInput input)
        {
            return _agentGroupTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AgentGroupTypeDto> GetAsync(int id)
        {
            return _agentGroupTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AgentGroupTypeDto> CreateAsync(AgentGroupTypeCreateDto input)
        {
            return _agentGroupTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AgentGroupTypeDto> UpdateAsync(int id, AgentGroupTypeUpdateDto input)
        {
            return _agentGroupTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _agentGroupTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentGroupTypeExcelDownloadDto input)
        {
            return _agentGroupTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _agentGroupTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> agentgrouptypeIds)
        {
            return _agentGroupTypesAppService.DeleteByIdsAsync(agentgrouptypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetAgentGroupTypesInput input)
        {
            return _agentGroupTypesAppService.DeleteAllAsync(input);
        }
    }
}