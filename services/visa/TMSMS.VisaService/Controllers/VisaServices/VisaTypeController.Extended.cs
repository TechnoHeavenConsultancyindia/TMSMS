using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.VisaService.VisaServices;

namespace TMSMS.VisaService.VisaServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("VisaType")]
    [Route("api/visa/visa-types")]

    public class VisaTypeController : VisaTypeControllerBase, IVisaTypesAppService
    {
        public VisaTypeController(IVisaTypesAppService visaTypesAppService) : base(visaTypesAppService)
        {
        }
    }
}