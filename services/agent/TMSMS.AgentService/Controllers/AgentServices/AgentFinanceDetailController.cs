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
    [ControllerName("AgentFinanceDetail")]
    [Route("api/agent/agent-finance-details")]

    public abstract class AgentFinanceDetailControllerBase : AbpController
    {
        protected IAgentFinanceDetailsAppService _agentFinanceDetailsAppService;

        public AgentFinanceDetailControllerBase(IAgentFinanceDetailsAppService agentFinanceDetailsAppService)
        {
            _agentFinanceDetailsAppService = agentFinanceDetailsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AgentFinanceDetailDto>> GetListAsync(GetAgentFinanceDetailsInput input)
        {
            return _agentFinanceDetailsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AgentFinanceDetailDto> GetAsync(int id)
        {
            return _agentFinanceDetailsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AgentFinanceDetailDto> CreateAsync(AgentFinanceDetailCreateDto input)
        {
            return _agentFinanceDetailsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AgentFinanceDetailDto> UpdateAsync(int id, AgentFinanceDetailUpdateDto input)
        {
            return _agentFinanceDetailsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _agentFinanceDetailsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentFinanceDetailExcelDownloadDto input)
        {
            return _agentFinanceDetailsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _agentFinanceDetailsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> agentfinancedetailIds)
        {
            return _agentFinanceDetailsAppService.DeleteByIdsAsync(agentfinancedetailIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetAgentFinanceDetailsInput input)
        {
            return _agentFinanceDetailsAppService.DeleteAllAsync(input);
        }
    }
}