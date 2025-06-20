using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.TransferService.TransferServices;
using Volo.Abp.Content;
using TMSMS.TransferService.Shared;

namespace TMSMS.TransferService.TransferServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("TransferType")]
    [Route("api/transfer/transfer-types")]

    public abstract class TransferTypeControllerBase : AbpController
    {
        protected ITransferTypesAppService _transferTypesAppService;

        public TransferTypeControllerBase(ITransferTypesAppService transferTypesAppService)
        {
            _transferTypesAppService = transferTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TransferTypeDto>> GetListAsync(GetTransferTypesInput input)
        {
            return _transferTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TransferTypeDto> GetAsync(int id)
        {
            return _transferTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<TransferTypeDto> CreateAsync(TransferTypeCreateDto input)
        {
            return _transferTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TransferTypeDto> UpdateAsync(int id, TransferTypeUpdateDto input)
        {
            return _transferTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _transferTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(TransferTypeExcelDownloadDto input)
        {
            return _transferTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.TransferService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _transferTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> transfertypeIds)
        {
            return _transferTypesAppService.DeleteByIdsAsync(transfertypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetTransferTypesInput input)
        {
            return _transferTypesAppService.DeleteAllAsync(input);
        }
    }
}