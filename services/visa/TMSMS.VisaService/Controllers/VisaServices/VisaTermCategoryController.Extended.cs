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
    [ControllerName("VisaTermCategory")]
    [Route("api/visa/visa-term-categories")]

    public class VisaTermCategoryController : VisaTermCategoryControllerBase, IVisaTermCategoriesAppService
    {
        public VisaTermCategoryController(IVisaTermCategoriesAppService visaTermCategoriesAppService) : base(visaTermCategoriesAppService)
        {
        }
    }
}