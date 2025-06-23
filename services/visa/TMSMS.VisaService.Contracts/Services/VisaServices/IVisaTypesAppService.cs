using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.VisaService.Shared;

namespace TMSMS.VisaService.VisaServices
{
    public partial interface IVisaTypesAppService : IApplicationService
    {

        Task<PagedResultDto<VisaTypeDto>> GetListAsync(GetVisaTypesInput input);

        Task<VisaTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<VisaTypeDto> CreateAsync(VisaTypeCreateDto input);

        Task<VisaTypeDto> UpdateAsync(int id, VisaTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> visatypeIds);

        Task DeleteAllAsync(GetVisaTypesInput input);
        Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}