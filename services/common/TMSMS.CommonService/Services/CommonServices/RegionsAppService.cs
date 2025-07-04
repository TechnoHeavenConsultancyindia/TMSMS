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
    [Authorize(CommonServicePermissions.Regions.Default)]
    public abstract class RegionsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<RegionDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IRegionRepository _regionRepository;
        protected RegionManager _regionManager;

        public RegionsAppServiceBase(IRegionRepository regionRepository, RegionManager regionManager, IDistributedCache<RegionDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _regionRepository = regionRepository;
            _regionManager = regionManager;

        }

        public virtual async Task<PagedResultDto<RegionDto>> GetListAsync(GetRegionsInput input)
        {
            var totalCount = await _regionRepository.GetCountAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor);
            var items = await _regionRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<RegionDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Region>, List<RegionDto>>(items)
            };
        }

        public virtual async Task<RegionDto> GetAsync(int id)
        {
            return ObjectMapper.Map<Region, RegionDto>(await _regionRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.Regions.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _regionRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.Regions.Create)]
        public virtual async Task<RegionDto> CreateAsync(RegionCreateDto input)
        {

            var region = await _regionManager.CreateAsync(
            input.Name, input.StatusFlag, input.LocationId, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.Descriptor
            );

            return ObjectMapper.Map<Region, RegionDto>(region);
        }

        [Authorize(CommonServicePermissions.Regions.Edit)]
        public virtual async Task<RegionDto> UpdateAsync(int id, RegionUpdateDto input)
        {

            var region = await _regionManager.UpdateAsync(
            id,
            input.Name, input.StatusFlag, input.LocationId, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.Descriptor, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Region, RegionDto>(region);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(RegionExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _regionRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Region>, List<RegionExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Regions.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.Regions.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> regionIds)
        {
            await _regionRepository.DeleteManyAsync(regionIds);
        }

        [Authorize(CommonServicePermissions.Regions.Delete)]
        public virtual async Task DeleteAllAsync(GetRegionsInput input)
        {
            await _regionRepository.DeleteAllAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new RegionDownloadTokenCacheItem { Token = token },
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