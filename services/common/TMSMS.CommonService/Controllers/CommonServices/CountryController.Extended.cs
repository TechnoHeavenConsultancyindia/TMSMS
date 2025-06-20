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
    [ControllerName("Country")]
    [Route("api/common/countries")]

    public class CountryController : CountryControllerBase, ICountriesAppService
    {
        public CountryController(ICountriesAppService countriesAppService) : base(countriesAppService)
        {
        }
    }
}