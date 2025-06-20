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
using TMSMS.CommonService.Permissions;
using TMSMS.CommonService.CommonServices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService(IsEnabled = false)]
    [Authorize(CommonServicePermissions.Cities.Default)]
    public abstract class CitiesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<CityDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ICityRepository _cityRepository;
        protected CityManager _cityManager;

        public CitiesAppServiceBase(ICityRepository cityRepository, CityManager cityManager, IDistributedCache<CityDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _cityRepository = cityRepository;
            _cityManager = cityManager;

        }

        public virtual async Task<PagedResultDto<CityDto>> GetListAsync(GetCitiesInput input)
        {
            var totalCount = await _cityRepository.GetCountAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax);
            var items = await _cityRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<City>, List<CityDto>>(items)
            };
        }

        public virtual async Task<CityDto> GetAsync(int id)
        {
            return ObjectMapper.Map<City, CityDto>(await _cityRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.Cities.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.Cities.Create)]
        public virtual async Task<CityDto> CreateAsync(CityCreateDto input)
        {

            var city = await _cityManager.CreateAsync(
            input.Name, input.StatusFlag, input.LocationId, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags
            );

            return ObjectMapper.Map<City, CityDto>(city);
        }

        [Authorize(CommonServicePermissions.Cities.Edit)]
        public virtual async Task<CityDto> UpdateAsync(int id, CityUpdateDto input)
        {

            var city = await _cityManager.UpdateAsync(
            id,
            input.Name, input.StatusFlag, input.LocationId, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<City, CityDto>(city);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CityExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _cityRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<City>, List<CityExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Cities.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.Cities.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> cityIds)
        {
            await _cityRepository.DeleteManyAsync(cityIds);
        }

        [Authorize(CommonServicePermissions.Cities.Delete)]
        public virtual async Task DeleteAllAsync(GetCitiesInput input)
        {
            await _cityRepository.DeleteAllAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new CityDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TMSMS.CommonService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}