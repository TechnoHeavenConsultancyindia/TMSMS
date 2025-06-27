using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.RestaurantService.Shared;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public partial interface IRestaurantCuisinesAppService : IApplicationService
    {

        Task<PagedResultDto<RestaurantCuisineDto>> GetListAsync(GetRestaurantCuisinesInput input);

        Task<RestaurantCuisineDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<RestaurantCuisineDto> CreateAsync(RestaurantCuisineCreateDto input);

        Task<RestaurantCuisineDto> UpdateAsync(int id, RestaurantCuisineUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantCuisineExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> restaurantcuisineIds);

        Task DeleteAllAsync(GetRestaurantCuisinesInput input);
        Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}