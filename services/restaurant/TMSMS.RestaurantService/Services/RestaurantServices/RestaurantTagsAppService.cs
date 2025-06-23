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
    [Authorize(RestaurantServicePermissions.RestaurantTags.Default)]
    public abstract class RestaurantTagsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<RestaurantTagDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IRestaurantTagRepository _restaurantTagRepository;
        protected RestaurantTagManager _restaurantTagManager;

        public RestaurantTagsAppServiceBase(IRestaurantTagRepository restaurantTagRepository, RestaurantTagManager restaurantTagManager, IDistributedCache<RestaurantTagDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _restaurantTagRepository = restaurantTagRepository;
            _restaurantTagManager = restaurantTagManager;

        }

        public virtual async Task<PagedResultDto<RestaurantTagDto>> GetListAsync(GetRestaurantTagsInput input)
        {
            var totalCount = await _restaurantTagRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _restaurantTagRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<RestaurantTagDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<RestaurantTag>, List<RestaurantTagDto>>(items)
            };
        }

        public virtual async Task<RestaurantTagDto> GetAsync(int id)
        {
            return ObjectMapper.Map<RestaurantTag, RestaurantTagDto>(await _restaurantTagRepository.GetAsync(id));
        }

        [Authorize(RestaurantServicePermissions.RestaurantTags.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _restaurantTagRepository.DeleteAsync(id);
        }

        [Authorize(RestaurantServicePermissions.RestaurantTags.Create)]
        public virtual async Task<RestaurantTagDto> CreateAsync(RestaurantTagCreateDto input)
        {

            var restaurantTag = await _restaurantTagManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<RestaurantTag, RestaurantTagDto>(restaurantTag);
        }

        [Authorize(RestaurantServicePermissions.RestaurantTags.Edit)]
        public virtual async Task<RestaurantTagDto> UpdateAsync(int id, RestaurantTagUpdateDto input)
        {

            var restaurantTag = await _restaurantTagManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<RestaurantTag, RestaurantTagDto>(restaurantTag);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantTagExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _restaurantTagRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<RestaurantTag>, List<RestaurantTagExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "RestaurantTags.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(RestaurantServicePermissions.RestaurantTags.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> restauranttagIds)
        {
            await _restaurantTagRepository.DeleteManyAsync(restauranttagIds);
        }

        [Authorize(RestaurantServicePermissions.RestaurantTags.Delete)]
        public virtual async Task DeleteAllAsync(GetRestaurantTagsInput input)
        {
            await _restaurantTagRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new RestaurantTagDownloadTokenCacheItem { Token = token },
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