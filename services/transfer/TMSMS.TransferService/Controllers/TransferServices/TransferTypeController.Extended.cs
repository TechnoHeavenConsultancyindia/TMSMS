using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.TransferService.TransferServices;

namespace TMSMS.TransferService.TransferServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("TransferType")]
    [Route("api/transfer/transfer-types")]

    public class TransferTypeController : TransferTypeControllerBase, ITransferTypesAppService
    {
        public TransferTypeController(ITransferTypesAppService transferTypesAppService) : base(transferTypesAppService)
        {
        }
    }
}