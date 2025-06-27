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
    [ControllerName("AgentFinanceDetail")]
    [Route("api/agent/agent-finance-details")]

    public class AgentFinanceDetailController : AgentFinanceDetailControllerBase, IAgentFinanceDetailsAppService
    {
        public AgentFinanceDetailController(IAgentFinanceDetailsAppService agentFinanceDetailsAppService) : base(agentFinanceDetailsAppService)
        {
        }
    }
}