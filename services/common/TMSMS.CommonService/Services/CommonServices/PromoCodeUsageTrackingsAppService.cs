using TMSMS.CommonService.Shared;
using TMSMS.CommonService.CommonServices;
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
    [Authorize(CommonServicePermissions.PromoCodeUsageTrackings.Default)]
    public abstract class PromoCodeUsageTrackingsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PromoCodeUsageTrackingDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IPromoCodeUsageTrackingRepository _promoCodeUsageTrackingRepository;
        protected PromoCodeUsageTrackingManager _promoCodeUsageTrackingManager;

        protected IRepository<TMSMS.CommonService.CommonServices.PromoCodeMaster, int> _promoCodeMasterRepository;

        public PromoCodeUsageTrackingsAppServiceBase(IPromoCodeUsageTrackingRepository promoCodeUsageTrackingRepository, PromoCodeUsageTrackingManager promoCodeUsageTrackingManager, IDistributedCache<PromoCodeUsageTrackingDownloadTokenCacheItem, string> downloadTokenCache, IRepository<TMSMS.CommonService.CommonServices.PromoCodeMaster, int> promoCodeMasterRepository)
        {
            _downloadTokenCache = downloadTokenCache;
            _promoCodeUsageTrackingRepository = promoCodeUsageTrackingRepository;
            _promoCodeUsageTrackingManager = promoCodeUsageTrackingManager; _promoCodeMasterRepository = promoCodeMasterRepository;

        }

        public virtual async Task<PagedResultDto<PromoCodeUsageTrackingWithNavigationPropertiesDto>> GetListAsync(GetPromoCodeUsageTrackingsInput input)
        {
            var totalCount = await _promoCodeUsageTrackingRepository.GetCountAsync(input.FilterText, input.UserIDMin, input.UserIDMax, input.BookingIDMin, input.BookingIDMax, input.UsageDateMin, input.UsageDateMax, input.PromoCodeMasterId);
            var items = await _promoCodeUsageTrackingRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.UserIDMin, input.UserIDMax, input.BookingIDMin, input.BookingIDMax, input.UsageDateMin, input.UsageDateMax, input.PromoCodeMasterId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PromoCodeUsageTrackingWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PromoCodeUsageTrackingWithNavigationProperties>, List<PromoCodeUsageTrackingWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<PromoCodeUsageTrackingWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return ObjectMapper.Map<PromoCodeUsageTrackingWithNavigationProperties, PromoCodeUsageTrackingWithNavigationPropertiesDto>
                (await _promoCodeUsageTrackingRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<PromoCodeUsageTrackingDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PromoCodeUsageTracking, PromoCodeUsageTrackingDto>(await _promoCodeUsageTrackingRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<int>>> GetPromoCodeMasterLookupAsync(LookupRequestDto input)
        {
            var query = (await _promoCodeMasterRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<TMSMS.CommonService.CommonServices.PromoCodeMaster>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<int>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TMSMS.CommonService.CommonServices.PromoCodeMaster>, List<LookupDto<int>>>(lookupData)
            };
        }

        [Authorize(CommonServicePermissions.PromoCodeUsageTrackings.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _promoCodeUsageTrackingRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.PromoCodeUsageTrackings.Create)]
        public virtual async Task<PromoCodeUsageTrackingDto> CreateAsync(PromoCodeUsageTrackingCreateDto input)
        {

            var promoCodeUsageTracking = await _promoCodeUsageTrackingManager.CreateAsync(
            input.PromoCodeMasterId, input.UserID, input.BookingID, input.UsageDate
            );

            return ObjectMapper.Map<PromoCodeUsageTracking, PromoCodeUsageTrackingDto>(promoCodeUsageTracking);
        }

        [Authorize(CommonServicePermissions.PromoCodeUsageTrackings.Edit)]
        public virtual async Task<PromoCodeUsageTrackingDto> UpdateAsync(int id, PromoCodeUsageTrackingUpdateDto input)
        {

            var promoCodeUsageTracking = await _promoCodeUsageTrackingManager.UpdateAsync(
            id,
            input.PromoCodeMasterId, input.UserID, input.BookingID, input.UsageDate, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PromoCodeUsageTracking, PromoCodeUsageTrackingDto>(promoCodeUsageTracking);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PromoCodeUsageTrackingExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var promoCodeUsageTrackings = await _promoCodeUsageTrackingRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.UserIDMin, input.UserIDMax, input.BookingIDMin, input.BookingIDMax, input.UsageDateMin, input.UsageDateMax, input.PromoCodeMasterId);
            var items = promoCodeUsageTrackings.Select(item => new
            {
                UserID = item.PromoCodeUsageTracking.UserID,
                BookingID = item.PromoCodeUsageTracking.BookingID,
                UsageDate = item.PromoCodeUsageTracking.UsageDate,

                PromoCodeMaster = item.PromoCodeMaster?.Name,

            });

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(items);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PromoCodeUsageTrackings.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.PromoCodeUsageTrackings.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> promocodeusagetrackingIds)
        {
            await _promoCodeUsageTrackingRepository.DeleteManyAsync(promocodeusagetrackingIds);
        }

        [Authorize(CommonServicePermissions.PromoCodeUsageTrackings.Delete)]
        public virtual async Task DeleteAllAsync(GetPromoCodeUsageTrackingsInput input)
        {
            await _promoCodeUsageTrackingRepository.DeleteAllAsync(input.FilterText, input.UserIDMin, input.UserIDMax, input.BookingIDMin, input.BookingIDMax, input.UsageDateMin, input.UsageDateMax, input.PromoCodeMasterId);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new PromoCodeUsageTrackingDownloadTokenCacheItem { Token = token },
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