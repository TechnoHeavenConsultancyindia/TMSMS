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
    [ControllerName("Province")]
    [Route("api/common/provinces")]

    public class ProvinceController : ProvinceControllerBase, IProvincesAppService
    {
        public ProvinceController(IProvincesAppService provincesAppService) : base(provincesAppService)
        {
        }
    }
}