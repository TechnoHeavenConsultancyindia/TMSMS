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
    [ControllerName("City")]
    [Route("api/common/cities")]

    public class CityController : CityControllerBase, ICitiesAppService
    {
        public CityController(ICitiesAppService citiesAppService) : base(citiesAppService)
        {
        }
    }
}