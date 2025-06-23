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
    [ControllerName("RestaurantType")]
    [Route("api/restaurant/restaurant-types")]

    public abstract class RestaurantTypeControllerBase : AbpController
    {
        protected IRestaurantTypesAppService _restaurantTypesAppService;

        public RestaurantTypeControllerBase(IRestaurantTypesAppService restaurantTypesAppService)
        {
            _restaurantTypesAppService = restaurantTypesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RestaurantTypeDto>> GetListAsync(GetRestaurantTypesInput input)
        {
            return _restaurantTypesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RestaurantTypeDto> GetAsync(int id)
        {
            return _restaurantTypesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<RestaurantTypeDto> CreateAsync(RestaurantTypeCreateDto input)
        {
            return _restaurantTypesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<RestaurantTypeDto> UpdateAsync(int id, RestaurantTypeUpdateDto input)
        {
            return _restaurantTypesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _restaurantTypesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantTypeExcelDownloadDto input)
        {
            return _restaurantTypesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _restaurantTypesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> restauranttypeIds)
        {
            return _restaurantTypesAppService.DeleteByIdsAsync(restauranttypeIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetRestaurantTypesInput input)
        {
            return _restaurantTypesAppService.DeleteAllAsync(input);
        }
    }
}