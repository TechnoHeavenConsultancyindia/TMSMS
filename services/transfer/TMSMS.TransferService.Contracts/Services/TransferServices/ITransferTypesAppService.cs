using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.TransferService.Shared;

namespace TMSMS.TransferService.TransferServices
{
    public partial interface ITransferTypesAppService : IApplicationService
    {

        Task<PagedResultDto<TransferTypeDto>> GetListAsync(GetTransferTypesInput input);

        Task<TransferTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TransferTypeDto> CreateAsync(TransferTypeCreateDto input);

        Task<TransferTypeDto> UpdateAsync(int id, TransferTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TransferTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> transfertypeIds);

        Task DeleteAllAsync(GetTransferTypesInput input);
        Task<TMSMS.TransferService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}