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
    [ControllerName("SupplierMaster")]
    [Route("api/common/supplier-masters")]

    public class SupplierMasterController : SupplierMasterControllerBase, ISupplierMastersAppService
    {
        public SupplierMasterController(ISupplierMastersAppService supplierMastersAppService) : base(supplierMastersAppService)
        {
        }
    }
}