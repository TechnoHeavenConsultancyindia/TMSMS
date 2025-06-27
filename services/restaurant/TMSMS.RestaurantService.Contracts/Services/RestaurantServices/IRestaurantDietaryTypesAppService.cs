using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.RestaurantService.Shared;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public partial interface IRestaurantDietaryTypesAppService : IApplicationService
    {

        Task<PagedResultDto<RestaurantDietaryTypeDto>> GetListAsync(GetRestaurantDietaryTypesInput input);

        Task<RestaurantDietaryTypeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<RestaurantDietaryTypeDto> CreateAsync(RestaurantDietaryTypeCreateDto input);

        Task<RestaurantDietaryTypeDto> UpdateAsync(int id, RestaurantDietaryTypeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantDietaryTypeExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> restaurantdietarytypeIds);

        Task DeleteAllAsync(GetRestaurantDietaryTypesInput input);
        Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}