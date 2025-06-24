using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.RestaurantService.Shared;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public partial interface IRestaurantTypesAppService : IApplicationService
    {

        Task<PagedResultDto<RestaurantTypeDto>> GetListAsync(GetRestaurantTypesInput input);

        Task<RestaurantTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<RestaurantTypeDto> CreateAsync(RestaurantTypeCreateDto input);

        Task<RestaurantTypeDto> UpdateAsync(int id, RestaurantTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> restauranttypeIds);

        Task DeleteAllAsync(GetRestaurantTypesInput input);
        Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}