using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.CommonService.CommonServices;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Region")]
    [Route("api/common/regions")]

    public class RegionController : RegionControllerBase, IRegionsAppService
    {
        public RegionController(IRegionsAppService regionsAppService) : base(regionsAppService)
        {
        }
    }
}