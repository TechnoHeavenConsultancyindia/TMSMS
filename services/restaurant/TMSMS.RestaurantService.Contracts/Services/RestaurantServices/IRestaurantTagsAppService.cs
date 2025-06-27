using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.RestaurantService.Shared;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public partial interface IRestaurantTagsAppService : IApplicationService
    {

        Task<PagedResultDto<RestaurantTagDto>> GetListAsync(GetRestaurantTagsInput input);

        Task<RestaurantTagDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<RestaurantTagDto> CreateAsync(RestaurantTagCreateDto input);

        Task<RestaurantTagDto> UpdateAsync(int id, RestaurantTagUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantTagExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> restauranttagIds);

        Task DeleteAllAsync(GetRestaurantTagsInput input);
        Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}