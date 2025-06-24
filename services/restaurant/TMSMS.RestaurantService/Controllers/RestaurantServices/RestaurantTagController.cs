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
    [ControllerName("RestaurantTag")]
    [Route("api/restaurant/restaurant-tags")]

    public abstract class RestaurantTagControllerBase : AbpController
    {
        protected IRestaurantTagsAppService _restaurantTagsAppService;

        public RestaurantTagControllerBase(IRestaurantTagsAppService restaurantTagsAppService)
        {
            _restaurantTagsAppService = restaurantTagsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RestaurantTagDto>> GetListAsync(GetRestaurantTagsInput input)
        {
            return _restaurantTagsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RestaurantTagDto> GetAsync(int id)
        {
            return _restaurantTagsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<RestaurantTagDto> CreateAsync(RestaurantTagCreateDto input)
        {
            return _restaurantTagsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<RestaurantTagDto> UpdateAsync(int id, RestaurantTagUpdateDto input)
        {
            return _restaurantTagsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _restaurantTagsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantTagExcelDownloadDto input)
        {
            return _restaurantTagsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _restaurantTagsAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> restauranttagIds)
        {
            return _restaurantTagsAppService.DeleteByIdsAsync(restauranttagIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetRestaurantTagsInput input)
        {
            return _restaurantTagsAppService.DeleteAllAsync(input);
        }
    }
}