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
    [Authorize(CommonServicePermissions.PromoCodeMasters.Default)]
    public abstract class PromoCodeMastersAppServiceBase : ApplicationService
    {
        protected IDistributedCache<PromoCodeMasterDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IPromoCodeMasterRepository _promoCodeMasterRepository;
        protected PromoCodeMasterManager _promoCodeMasterManager;

        protected IRepository<TMSMS.CommonService.CommonServices.Country, int> _countryRepository;
        protected IRepository<TMSMS.CommonService.CommonServices.City, int> _cityRepository;

        public PromoCodeMastersAppServiceBase(IPromoCodeMasterRepository promoCodeMasterRepository, PromoCodeMasterManager promoCodeMasterManager, IDistributedCache<PromoCodeMasterDownloadTokenCacheItem, string> downloadTokenCache, IRepository<TMSMS.CommonService.CommonServices.Country, int> countryRepository, IRepository<TMSMS.CommonService.CommonServices.City, int> cityRepository)
        {
            _downloadTokenCache = downloadTokenCache;
            _promoCodeMasterRepository = promoCodeMasterRepository;
            _promoCodeMasterManager = promoCodeMasterManager; _countryRepository = countryRepository;
            _cityRepository = cityRepository;

        }

        public virtual async Task<PagedResultDto<PromoCodeMasterWithNavigationPropertiesDto>> GetListAsync(GetPromoCodeMastersInput input)
        {
            var totalCount = await _promoCodeMasterRepository.GetCountAsync(input.FilterText, input.Name, input.PromoCode, input.ServiceType, input.DiscountType, input.DiscountValueMin, input.DiscountValueMax, input.DateEffectiveFromMin, input.DateEffectiveFromMax, input.DateEffectiveToMin, input.DateEffectiveToMax, input.MaxUsageLimitMin, input.MaxUsageLimitMax, input.MaxUsagePerUserMin, input.MaxUsagePerUserMax, input.CustomerType, input.MinBookingAmountMin, input.MinBookingAmountMax, input.PaymentMethod, input.UserGroup, input.MinNoOfNightsMin, input.MinNoOfNightsMax, input.MinNoOfPaxMin, input.MinNoOfPaxMax, input.EarlyBirdDaysMin, input.EarlyBirdDaysMax, input.ValidTimeFromMin, input.ValidTimeFromMax, input.ValidTimeToMin, input.ValidTimeToMax, input.Stackable, input.CountryId, input.CityId);
            var items = await _promoCodeMasterRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Name, input.PromoCode, input.ServiceType, input.DiscountType, input.DiscountValueMin, input.DiscountValueMax, input.DateEffectiveFromMin, input.DateEffectiveFromMax, input.DateEffectiveToMin, input.DateEffectiveToMax, input.MaxUsageLimitMin, input.MaxUsageLimitMax, input.MaxUsagePerUserMin, input.MaxUsagePerUserMax, input.CustomerType, input.MinBookingAmountMin, input.MinBookingAmountMax, input.PaymentMethod, input.UserGroup, input.MinNoOfNightsMin, input.MinNoOfNightsMax, input.MinNoOfPaxMin, input.MinNoOfPaxMax, input.EarlyBirdDaysMin, input.EarlyBirdDaysMax, input.ValidTimeFromMin, input.ValidTimeFromMax, input.ValidTimeToMin, input.ValidTimeToMax, input.Stackable, input.CountryId, input.CityId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PromoCodeMasterWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PromoCodeMasterWithNavigationProperties>, List<PromoCodeMasterWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<PromoCodeMasterWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return ObjectMapper.Map<PromoCodeMasterWithNavigationProperties, PromoCodeMasterWithNavigationPropertiesDto>
                (await _promoCodeMasterRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<PromoCodeMasterDto> GetAsync(int id)
        {
            return ObjectMapper.Map<PromoCodeMaster, PromoCodeMasterDto>(await _promoCodeMasterRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<int>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            var query = (await _countryRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<TMSMS.CommonService.CommonServices.Country>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<int>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TMSMS.CommonService.CommonServices.Country>, List<LookupDto<int>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<int>>> GetCityLookupAsync(LookupRequestDto input)
        {
            var query = (await _cityRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<TMSMS.CommonService.CommonServices.City>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<int>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TMSMS.CommonService.CommonServices.City>, List<LookupDto<int>>>(lookupData)
            };
        }

        [Authorize(CommonServicePermissions.PromoCodeMasters.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _promoCodeMasterRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.PromoCodeMasters.Create)]
        public virtual async Task<PromoCodeMasterDto> CreateAsync(PromoCodeMasterCreateDto input)
        {

            var promoCodeMaster = await _promoCodeMasterManager.CreateAsync(
            input.CountryIds, input.CityIds, input.Name, input.DiscountValue, input.DateEffectiveFrom, input.DateEffectiveTo, input.MinBookingAmount, input.MinNoOfNights, input.MinNoOfPax, input.EarlyBirdDays, input.ValidTimeFrom, input.ValidTimeTo, input.Stackable, input.PromoCode, input.ServiceType, input.DiscountType, input.MaxUsageLimit, input.MaxUsagePerUser, input.CustomerType, input.PaymentMethod, input.UserGroup
            );

            return ObjectMapper.Map<PromoCodeMaster, PromoCodeMasterDto>(promoCodeMaster);
        }

        [Authorize(CommonServicePermissions.PromoCodeMasters.Edit)]
        public virtual async Task<PromoCodeMasterDto> UpdateAsync(int id, PromoCodeMasterUpdateDto input)
        {

            var promoCodeMaster = await _promoCodeMasterManager.UpdateAsync(
            id,
            input.CountryIds, input.CityIds, input.Name, input.DiscountValue, input.DateEffectiveFrom, input.DateEffectiveTo, input.MinBookingAmount, input.MinNoOfNights, input.MinNoOfPax, input.EarlyBirdDays, input.ValidTimeFrom, input.ValidTimeTo, input.Stackable, input.PromoCode, input.ServiceType, input.DiscountType, input.MaxUsageLimit, input.MaxUsagePerUser, input.CustomerType, input.PaymentMethod, input.UserGroup, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<PromoCodeMaster, PromoCodeMasterDto>(promoCodeMaster);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(PromoCodeMasterExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var promoCodeMasters = await _promoCodeMasterRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Name, input.PromoCode, input.ServiceType, input.DiscountType, input.DiscountValueMin, input.DiscountValueMax, input.DateEffectiveFromMin, input.DateEffectiveFromMax, input.DateEffectiveToMin, input.DateEffectiveToMax, input.MaxUsageLimitMin, input.MaxUsageLimitMax, input.MaxUsagePerUserMin, input.MaxUsagePerUserMax, input.CustomerType, input.MinBookingAmountMin, input.MinBookingAmountMax, input.PaymentMethod, input.UserGroup, input.MinNoOfNightsMin, input.MinNoOfNightsMax, input.MinNoOfPaxMin, input.MinNoOfPaxMax, input.EarlyBirdDaysMin, input.EarlyBirdDaysMax, input.ValidTimeFromMin, input.ValidTimeFromMax, input.ValidTimeToMin, input.ValidTimeToMax, input.Stackable, input.CountryId, input.CityId);
            var items = promoCodeMasters.Select(item => new
            {
                Name = item.PromoCodeMaster.Name,
                PromoCode = item.PromoCodeMaster.PromoCode,
                ServiceType = item.PromoCodeMaster.ServiceType,
                DiscountType = item.PromoCodeMaster.DiscountType,
                DiscountValue = item.PromoCodeMaster.DiscountValue,
                DateEffectiveFrom = item.PromoCodeMaster.DateEffectiveFrom,
                DateEffectiveTo = item.PromoCodeMaster.DateEffectiveTo,
                MaxUsageLimit = item.PromoCodeMaster.MaxUsageLimit,
                MaxUsagePerUser = item.PromoCodeMaster.MaxUsagePerUser,
                CustomerType = item.PromoCodeMaster.CustomerType,
                MinBookingAmount = item.PromoCodeMaster.MinBookingAmount,
                PaymentMethod = item.PromoCodeMaster.PaymentMethod,
                UserGroup = item.PromoCodeMaster.UserGroup,
                MinNoOfNights = item.PromoCodeMaster.MinNoOfNights,
                MinNoOfPax = item.PromoCodeMaster.MinNoOfPax,
                EarlyBirdDays = item.PromoCodeMaster.EarlyBirdDays,
                ValidTimeFrom = item.PromoCodeMaster.ValidTimeFrom,
                ValidTimeTo = item.PromoCodeMaster.ValidTimeTo,
                Stackable = item.PromoCodeMaster.Stackable,

            });

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(items);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "PromoCodeMasters.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.PromoCodeMasters.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> promocodemasterIds)
        {
            await _promoCodeMasterRepository.DeleteManyAsync(promocodemasterIds);
        }

        [Authorize(CommonServicePermissions.PromoCodeMasters.Delete)]
        public virtual async Task DeleteAllAsync(GetPromoCodeMastersInput input)
        {
            await _promoCodeMasterRepository.DeleteAllAsync(input.FilterText, input.Name, input.PromoCode, input.ServiceType, input.DiscountType, input.DiscountValueMin, input.DiscountValueMax, input.DateEffectiveFromMin, input.DateEffectiveFromMax, input.DateEffectiveToMin, input.DateEffectiveToMax, input.MaxUsageLimitMin, input.MaxUsageLimitMax, input.MaxUsagePerUserMin, input.MaxUsagePerUserMax, input.CustomerType, input.MinBookingAmountMin, input.MinBookingAmountMax, input.PaymentMethod, input.UserGroup, input.MinNoOfNightsMin, input.MinNoOfNightsMax, input.MinNoOfPaxMin, input.MinNoOfPaxMax, input.EarlyBirdDaysMin, input.EarlyBirdDaysMax, input.ValidTimeFromMin, input.ValidTimeFromMax, input.ValidTimeToMin, input.ValidTimeToMax, input.Stackable, input.CountryId, input.CityId);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new PromoCodeMasterDownloadTokenCacheItem { Token = token },
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