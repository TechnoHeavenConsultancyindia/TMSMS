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
    [ControllerName("AgentGroupType")]
    [Route("api/agent/agent-group-types")]

    public class AgentGroupTypeController : AgentGroupTypeControllerBase, IAgentGroupTypesAppService
    {
        public AgentGroupTypeController(IAgentGroupTypesAppService agentGroupTypesAppService) : base(agentGroupTypesAppService)
        {
        }
    }
}