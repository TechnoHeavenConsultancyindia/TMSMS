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
    [ControllerName("AgentVoucherType")]
    [Route("api/agent/agent-voucher-types")]

    public abstract class AgentVoucherTypeControllerBase : AbpController
    {
        protected IAgentVoucherTypesAppService _agentVoucherTypesAppService;

        public AgentVoucherTypeControllerBase(IAgentVoucherTypesAppService agentVoucherTypesAppService)
        {
            _agentVoucherTypesAppService = agentVoucherTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AgentVoucherTypeDto>> GetListAsync(GetAgentVoucherTypesInput input)
        {
            return _agentVoucherTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AgentVoucherTypeDto> GetAsync(int id)
        {
            return _agentVoucherTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AgentVoucherTypeDto> CreateAsync(AgentVoucherTypeCreateDto input)
        {
            return _agentVoucherTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AgentVoucherTypeDto> UpdateAsync(int id, AgentVoucherTypeUpdateDto input)
        {
            return _agentVoucherTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _agentVoucherTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentVoucherTypeExcelDownloadDto input)
        {
            return _agentVoucherTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _agentVoucherTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> agentvouchertypeIds)
        {
            return _agentVoucherTypesAppService.DeleteByIdsAsync(agentvouchertypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetAgentVoucherTypesInput input)
        {
            return _agentVoucherTypesAppService.DeleteAllAsync(input);
        }
    }
}