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
    [Authorize(RestaurantServicePermissions.RestaurantDietaryTypes.Default)]
    public abstract class RestaurantDietaryTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<RestaurantDietaryTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IRestaurantDietaryTypeRepository _restaurantDietaryTypeRepository;
        protected RestaurantDietaryTypeManager _restaurantDietaryTypeManager;

        public RestaurantDietaryTypesAppServiceBase(IRestaurantDietaryTypeRepository restaurantDietaryTypeRepository, RestaurantDietaryTypeManager restaurantDietaryTypeManager, IDistributedCache<RestaurantDietaryTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _restaurantDietaryTypeRepository = restaurantDietaryTypeRepository;
            _restaurantDietaryTypeManager = restaurantDietaryTypeManager;

        }

        public virtual async Task<PagedResultDto<RestaurantDietaryTypeDto>> GetListAsync(GetRestaurantDietaryTypesInput input)
        {
            var totalCount = await _restaurantDietaryTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _restaurantDietaryTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<RestaurantDietaryTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<RestaurantDietaryType>, List<RestaurantDietaryTypeDto>>(items)
            };
        }

        public virtual async Task<RestaurantDietaryTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<RestaurantDietaryType, RestaurantDietaryTypeDto>(await _restaurantDietaryTypeRepository.GetAsync(id));
        }

        [Authorize(RestaurantServicePermissions.RestaurantDietaryTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _restaurantDietaryTypeRepository.DeleteAsync(id);
        }

        [Authorize(RestaurantServicePermissions.RestaurantDietaryTypes.Create)]
        public virtual async Task<RestaurantDietaryTypeDto> CreateAsync(RestaurantDietaryTypeCreateDto input)
        {

            var restaurantDietaryType = await _restaurantDietaryTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<RestaurantDietaryType, RestaurantDietaryTypeDto>(restaurantDietaryType);
        }

        [Authorize(RestaurantServicePermissions.RestaurantDietaryTypes.Edit)]
        public virtual async Task<RestaurantDietaryTypeDto> UpdateAsync(int id, RestaurantDietaryTypeUpdateDto input)
        {

            var restaurantDietaryType = await _restaurantDietaryTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<RestaurantDietaryType, RestaurantDietaryTypeDto>(restaurantDietaryType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(RestaurantDietaryTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _restaurantDietaryTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<RestaurantDietaryType>, List<RestaurantDietaryTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "RestaurantDietaryTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(RestaurantServicePermissions.RestaurantDietaryTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> restaurantdietarytypeIds)
        {
            await _restaurantDietaryTypeRepository.DeleteManyAsync(restaurantdietarytypeIds);
        }

        [Authorize(RestaurantServicePermissions.RestaurantDietaryTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetRestaurantDietaryTypesInput input)
        {
            await _restaurantDietaryTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.RestaurantService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new RestaurantDietaryTypeDownloadTokenCacheItem { Token = token },
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