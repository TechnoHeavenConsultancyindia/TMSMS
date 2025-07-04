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
    [ControllerName("SupplierServiceType")]
    [Route("api/common/supplier-service-types")]

    public class SupplierServiceTypeController : SupplierServiceTypeControllerBase, ISupplierServiceTypesAppService
    {
        public SupplierServiceTypeController(ISupplierServiceTypesAppService supplierServiceTypesAppService) : base(supplierServiceTypesAppService)
        {
        }
    }
}