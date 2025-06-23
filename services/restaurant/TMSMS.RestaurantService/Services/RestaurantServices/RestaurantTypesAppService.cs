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
    [Authorize(RestaurantServicePermissions.RestaurantTypes.Default)]
    public abstract class RestaurantTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<RestaurantTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IRestaurantTypeRepository _restaurantTypeRepository;
        protected RestaurantTypeManager _restaurantTypeManager;

        public RestaurantTypesAppServiceBase(IRestaurantTypeRepository restaurantTypeRepository, RestaurantTypeManager restaurantTypeManager, IDistributedCache<RestaurantTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _restaurantTypeRepository = restaurantTypeRepository;
            _restaurantTypeManager = restaurantTypeManager;

        }

        public virtual async Task<PagedResultDto<RestaurantTypeDto>> GetListAsync(GetRestaurantTypesInput input)
        {
            var totalCount = await _restaurantTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _restaurantTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<RestaurantTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<RestaurantType>, List<RestaurantTypeDto>>(items)
            };
        }

        public virtual async Task<RestaurantTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<RestaurantType, RestaurantTypeDto>(await _restaurantTypeRepository.GetAsync(id));
        }

        [Authorize(RestaurantServicePermissions.RestaurantTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _restaurantTypeRepository.DeleteAsync(id);
        }

        [Authorize(RestaurantServicePermissions.RestaurantTypes.Create)]
        public virtual async Task<RestaurantTypeDto> CreateAsync(RestaurantTypeCreateDto input)
        {

            var restaurantType = await _restaurantTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<RestaurantType, RestaurantTypeDto>(restaurantType);
        }

        [Authorize(RestaurantServicePermissions.RestaurantTypes.Edit)]
        public virtual async Task<RestaurantTypeDto> UpdateAsync(int id, RestaurantTypeUpdateDto input)
        {

            var restaurantType = await _restaurantTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<RestaurantType, RestaurantTypeDto>(restaurantType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _restaurantTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<RestaurantType>, List<RestaurantTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "RestaurantTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(RestaurantServicePermissions.RestaurantTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> restauranttypeIds)
        {
            await _restaurantTypeRepository.DeleteManyAsync(restauranttypeIds);
        }

        [Authorize(RestaurantServicePermissions.RestaurantTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetRestaurantTypesInput input)
        {
            await _restaurantTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new RestaurantTypeDownloadTokenCacheItem { Token = token },
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