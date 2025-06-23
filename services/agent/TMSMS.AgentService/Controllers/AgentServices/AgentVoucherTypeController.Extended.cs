using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.AgentService.AgentServices;

namespace TMSMS.AgentService.AgentServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("AgentVoucherType")]
    [Route("api/agent/agent-voucher-types")]

    public class AgentVoucherTypeController : AgentVoucherTypeControllerBase, IAgentVoucherTypesAppService
    {
        public AgentVoucherTypeController(IAgentVoucherTypesAppService agentVoucherTypesAppService) : base(agentVoucherTypesAppService)
        {
        }
    }
}