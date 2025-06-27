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
    [ControllerName("VisaDiscountCategory")]
    [Route("api/visa/visa-discount-categories")]

    public class VisaDiscountCategoryController : VisaDiscountCategoryControllerBase, IVisaDiscountCategoriesAppService
    {
        public VisaDiscountCategoryController(IVisaDiscountCategoriesAppService visaDiscountCategoriesAppService) : base(visaDiscountCategoriesAppService)
        {
        }
    }
}