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
    [ControllerName("RestaurantCuisine")]
    [Route("api/restaurant/restaurant-cuisines")]

    public abstract class RestaurantCuisineControllerBase : AbpController
    {
        protected IRestaurantCuisinesAppService _restaurantCuisinesAppService;

        public RestaurantCuisineControllerBase(IRestaurantCuisinesAppService restaurantCuisinesAppService)
        {
            _restaurantCuisinesAppService = restaurantCuisinesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RestaurantCuisineDto>> GetListAsync(GetRestaurantCuisinesInput input)
        {
            return _restaurantCuisinesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RestaurantCuisineDto> GetAsync(int id)
        {
            return _restaurantCuisinesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<RestaurantCuisineDto> CreateAsync(RestaurantCuisineCreateDto input)
        {
            return _restaurantCuisinesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<RestaurantCuisineDto> UpdateAsync(int id, RestaurantCuisineUpdateDto input)
        {
            return _restaurantCuisinesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _restaurantCuisinesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantCuisineExcelDownloadDto input)
        {
            return _restaurantCuisinesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _restaurantCuisinesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> restaurantcuisineIds)
        {
            return _restaurantCuisinesAppService.DeleteByIdsAsync(restaurantcuisineIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetRestaurantCuisinesInput input)
        {
            return _restaurantCuisinesAppService.DeleteAllAsync(input);
        }
    }
}