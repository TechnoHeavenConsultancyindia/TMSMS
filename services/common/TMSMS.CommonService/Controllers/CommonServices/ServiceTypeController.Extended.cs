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
    [ControllerName("ServiceType")]
    [Route("api/common/service-types")]

    public class ServiceTypeController : ServiceTypeControllerBase, IServiceTypesAppService
    {
        public ServiceTypeController(IServiceTypesAppService serviceTypesAppService) : base(serviceTypesAppService)
        {
        }
    }
}