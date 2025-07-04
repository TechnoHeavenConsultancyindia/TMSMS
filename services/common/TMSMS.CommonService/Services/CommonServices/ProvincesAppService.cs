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
    [Authorize(CommonServicePermissions.Provinces.Default)]
    public abstract class ProvincesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<ProvinceDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IProvinceRepository _provinceRepository;
        protected ProvinceManager _provinceManager;

        public ProvincesAppServiceBase(IProvinceRepository provinceRepository, ProvinceManager provinceManager, IDistributedCache<ProvinceDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _provinceRepository = provinceRepository;
            _provinceManager = provinceManager;

        }

        public virtual async Task<PagedResultDto<ProvinceDto>> GetListAsync(GetProvincesInput input)
        {
            var totalCount = await _provinceRepository.GetCountAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor);
            var items = await _provinceRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ProvinceDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Province>, List<ProvinceDto>>(items)
            };
        }

        public virtual async Task<ProvinceDto> GetAsync(int id)
        {
            return ObjectMapper.Map<Province, ProvinceDto>(await _provinceRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.Provinces.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _provinceRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.Provinces.Create)]
        public virtual async Task<ProvinceDto> CreateAsync(ProvinceCreateDto input)
        {

            var province = await _provinceManager.CreateAsync(
            input.Name, input.StatusFlag, input.LocationId, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.Descriptor
            );

            return ObjectMapper.Map<Province, ProvinceDto>(province);
        }

        [Authorize(CommonServicePermissions.Provinces.Edit)]
        public virtual async Task<ProvinceDto> UpdateAsync(int id, ProvinceUpdateDto input)
        {

            var province = await _provinceManager.UpdateAsync(
            id,
            input.Name, input.StatusFlag, input.LocationId, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.Descriptor, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Province, ProvinceDto>(province);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ProvinceExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _provinceRepository.GetListAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Province>, List<ProvinceExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Provinces.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.Provinces.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> provinceIds)
        {
            await _provinceRepository.DeleteManyAsync(provinceIds);
        }

        [Authorize(CommonServicePermissions.Provinces.Delete)]
        public virtual async Task DeleteAllAsync(GetProvincesInput input)
        {
            await _provinceRepository.DeleteAllAsync(input.FilterText, input.LocationId, input.Name, input.FullName, input.Latitude, input.Longitude, input.CountryCode, input.CountrySubdivisionCode, input.IataAirportCode, input.IataAirportMetroCode, input.PolygonType, input.Categories, input.Tags, input.StatusFlagMin, input.StatusFlagMax, input.Descriptor);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new ProvinceDownloadTokenCacheItem { Token = token },
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