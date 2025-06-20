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
    [Authorize(CommonServicePermissions.Countries.Default)]
    public abstract class CountriesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<CountryDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ICountryRepository _countryRepository;
        protected CountryManager _countryManager;

        public CountriesAppServiceBase(ICountryRepository countryRepository, CountryManager countryManager, IDistributedCache<CountryDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _countryRepository = countryRepository;
            _countryManager = countryManager;

        }

        public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            var totalCount = await _countryRepository.GetCountAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax);
            var items = await _countryRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<CountryDto>>(items)
            };
        }

        public virtual async Task<CountryDto> GetAsync(int id)
        {
            return ObjectMapper.Map<Country, CountryDto>(await _countryRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.Countries.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.Countries.Create)]
        public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {

            var country = await _countryManager.CreateAsync(
            input.Name, input.Categories, input.StatusFlag, input.LocationId, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Tags
            );

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [Authorize(CommonServicePermissions.Countries.Edit)]
        public virtual async Task<CountryDto> UpdateAsync(int id, CountryUpdateDto input)
        {

            var country = await _countryManager.UpdateAsync(
            id,
            input.Name, input.Categories, input.StatusFlag, input.LocationId, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Tags, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CountryExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _countryRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Country>, List<CountryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Countries.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.Countries.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> countryIds)
        {
            await _countryRepository.DeleteManyAsync(countryIds);
        }

        [Authorize(CommonServicePermissions.Countries.Delete)]
        public virtual async Task DeleteAllAsync(GetCountriesInput input)
        {
            await _countryRepository.DeleteAllAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Descriptor, input.IataAirportCode, input.IataAirportMetroCode, input.CountrySubdivisionCode, input.Latitude, input.Longitude, input.PolygonType, input.CountryCode, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new CountryDownloadTokenCacheItem { Token = token },
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