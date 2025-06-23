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
    [ControllerName("AgentPermissionType")]
    [Route("api/agent/agent-permission-types")]

    public class AgentPermissionTypeController : AgentPermissionTypeControllerBase, IAgentPermissionTypesAppService
    {
        public AgentPermissionTypeController(IAgentPermissionTypesAppService agentPermissionTypesAppService) : base(agentPermissionTypesAppService)
        {
        }
    }
}