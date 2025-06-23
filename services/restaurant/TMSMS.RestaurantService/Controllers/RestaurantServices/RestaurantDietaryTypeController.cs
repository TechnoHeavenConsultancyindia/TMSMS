using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.RestaurantService.RestaurantServices;
using Volo.Abp.Content;
using TMSMS.RestaurantService.Shared;

namespace TMSMS.RestaurantService.RestaurantServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("RestaurantDietaryType")]
    [Route("api/restaurant/restaurant-dietary-types")]

    public abstract class RestaurantDietaryTypeControllerBase : AbpController
    {
        protected IRestaurantDietaryTypesAppService _restaurantDietaryTypesAppService;

        public RestaurantDietaryTypeControllerBase(IRestaurantDietaryTypesAppService restaurantDietaryTypesAppService)
        {
            _restaurantDietaryTypesAppService = restaurantDietaryTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RestaurantDietaryTypeDto>> GetListAsync(GetRestaurantDietaryTypesInput input)
        {
            return _restaurantDietaryTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RestaurantDietaryTypeDto> GetAsync(int id)
        {
            return _restaurantDietaryTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<RestaurantDietaryTypeDto> CreateAsync(RestaurantDietaryTypeCreateDto input)
        {
            return _restaurantDietaryTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<RestaurantDietaryTypeDto> UpdateAsync(int id, RestaurantDietaryTypeUpdateDto input)
        {
            return _restaurantDietaryTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _restaurantDietaryTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantDietaryTypeExcelDownloadDto input)
        {
            return _restaurantDietaryTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _restaurantDietaryTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> restaurantdietarytypeIds)
        {
            return _restaurantDietaryTypesAppService.DeleteByIdsAsync(restaurantdietarytypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetRestaurantDietaryTypesInput input)
        {
            return _restaurantDietaryTypesAppService.DeleteAllAsync(input);
        }
    }
}