using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TMSMS.RestaurantService.Permissions;
using TMSMS.RestaurantService.RestaurantServices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TMSMS.RestaurantService.Shared;

namespace TMSMS.RestaurantService.RestaurantServices
{
    [RemoteService(IsEnabled = false)]
    [Authorize(RestaurantServicePermissions.RestaurantCuisines.Default)]
    public abstract class RestaurantCuisinesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<RestaurantCuisineDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IRestaurantCuisineRepository _restaurantCuisineRepository;
        protected RestaurantCuisineManager _restaurantCuisineManager;

        public RestaurantCuisinesAppServiceBase(IRestaurantCuisineRepository restaurantCuisineRepository, RestaurantCuisineManager restaurantCuisineManager, IDistributedCache<RestaurantCuisineDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _restaurantCuisineRepository = restaurantCuisineRepository;
            _restaurantCuisineManager = restaurantCuisineManager;

        }

        public virtual async Task<PagedResultDto<RestaurantCuisineDto>> GetListAsync(GetRestaurantCuisinesInput input)
        {
            var totalCount = await _restaurantCuisineRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _restaurantCuisineRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<RestaurantCuisineDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<RestaurantCuisine>, List<RestaurantCuisineDto>>(items)
            };
        }

        public virtual async Task<RestaurantCuisineDto> GetAsync(int id)
        {
            return ObjectMapper.Map<RestaurantCuisine, RestaurantCuisineDto>(await _restaurantCuisineRepository.GetAsync(id));
        }

        [Authorize(RestaurantServicePermissions.RestaurantCuisines.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _restaurantCuisineRepository.DeleteAsync(id);
        }

        [Authorize(RestaurantServicePermissions.RestaurantCuisines.Create)]
        public virtual async Task<RestaurantCuisineDto> CreateAsync(RestaurantCuisineCreateDto input)
        {

            var restaurantCuisine = await _restaurantCuisineManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<RestaurantCuisine, RestaurantCuisineDto>(restaurantCuisine);
        }

        [Authorize(RestaurantServicePermissions.RestaurantCuisines.Edit)]
        public virtual async Task<RestaurantCuisineDto> UpdateAsync(int id, RestaurantCuisineUpdateDto input)
        {

            var restaurantCuisine = await _restaurantCuisineManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<RestaurantCuisine, RestaurantCuisineDto>(restaurantCuisine);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantCuisineExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _restaurantCuisineRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<RestaurantCuisine>, List<RestaurantCuisineExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "RestaurantCuisines.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(RestaurantServicePermissions.RestaurantCuisines.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> restaurantcuisineIds)
        {
            await _restaurantCuisineRepository.DeleteManyAsync(restaurantcuisineIds);
        }

        [Authorize(RestaurantServicePermissions.RestaurantCuisines.Delete)]
        public virtual async Task DeleteAllAsync(GetRestaurantCuisinesInput input)
        {
            await _restaurantCuisineRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new RestaurantCuisineDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TMSMS.RestaurantService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}