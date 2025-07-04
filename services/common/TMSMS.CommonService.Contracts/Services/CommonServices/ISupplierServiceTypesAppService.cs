using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface ISupplierServiceTypesAppService : IApplicationService
    {

        Task<PagedResultDto<SupplierServiceTypeDto>> GetListAsync(GetSupplierServiceTypesInput input);

        Task<SupplierServiceTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<SupplierServiceTypeDto> CreateAsync(SupplierServiceTypeCreateDto input);

        Task<SupplierServiceTypeDto> UpdateAsync(int id, SupplierServiceTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SupplierServiceTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> supplierservicetypeIds);

        Task DeleteAllAsync(GetSupplierServiceTypesInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}