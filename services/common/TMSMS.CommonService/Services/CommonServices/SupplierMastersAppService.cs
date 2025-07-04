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
    [Authorize(CommonServicePermissions.SupplierMasters.Default)]
    public abstract class SupplierMastersAppServiceBase : ApplicationService
    {
        protected IDistributedCache<SupplierMasterDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ISupplierMasterRepository _supplierMasterRepository;
        protected SupplierMasterManager _supplierMasterManager;

        protected IRepository<TMSMS.CommonService.CommonServices.Country, int> _countryRepository;
        protected IRepository<TMSMS.CommonService.CommonServices.SupplierServiceType, int> _supplierServiceTypeRepository;

        public SupplierMastersAppServiceBase(ISupplierMasterRepository supplierMasterRepository, SupplierMasterManager supplierMasterManager, IDistributedCache<SupplierMasterDownloadTokenCacheItem, string> downloadTokenCache, IRepository<TMSMS.CommonService.CommonServices.Country, int> countryRepository, IRepository<TMSMS.CommonService.CommonServices.SupplierServiceType, int> supplierServiceTypeRepository)
        {
            _downloadTokenCache = downloadTokenCache;
            _supplierMasterRepository = supplierMasterRepository;
            _supplierMasterManager = supplierMasterManager; _countryRepository = countryRepository;
            _supplierServiceTypeRepository = supplierServiceTypeRepository;

        }

        public virtual async Task<PagedResultDto<SupplierMasterWithNavigationPropertiesDto>> GetListAsync(GetSupplierMastersInput input)
        {
            var totalCount = await _supplierMasterRepository.GetCountAsync(input.FilterText, input.Name, input.Type, input.ContactName, input.ContactEmail, input.DialCode, input.ContactPhone, input.SupplierStatus, input.Preffered, input.CountryId, input.SupplierServiceTypeId);
            var items = await _supplierMasterRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Name, input.Type, input.ContactName, input.ContactEmail, input.DialCode, input.ContactPhone, input.SupplierStatus, input.Preffered, input.CountryId, input.SupplierServiceTypeId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SupplierMasterWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SupplierMasterWithNavigationProperties>, List<SupplierMasterWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<SupplierMasterWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return ObjectMapper.Map<SupplierMasterWithNavigationProperties, SupplierMasterWithNavigationPropertiesDto>
                (await _supplierMasterRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<SupplierMasterDto> GetAsync(int id)
        {
            return ObjectMapper.Map<SupplierMaster, SupplierMasterDto>(await _supplierMasterRepository.GetAsync(id));
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

        public virtual async Task<PagedResultDto<LookupDto<int>>> GetSupplierServiceTypeLookupAsync(LookupRequestDto input)
        {
            var query = (await _supplierServiceTypeRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<TMSMS.CommonService.CommonServices.SupplierServiceType>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<int>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TMSMS.CommonService.CommonServices.SupplierServiceType>, List<LookupDto<int>>>(lookupData)
            };
        }

        [Authorize(CommonServicePermissions.SupplierMasters.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _supplierMasterRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.SupplierMasters.Create)]
        public virtual async Task<SupplierMasterDto> CreateAsync(SupplierMasterCreateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }
            if (input.SupplierServiceTypeId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["SupplierServiceType"]]);
            }

            var supplierMaster = await _supplierMasterManager.CreateAsync(
            input.CountryId, input.SupplierServiceTypeId, input.Name, input.Type, input.ContactName, input.SupplierStatus, input.Preffered, input.ContactEmail, input.DialCode, input.ContactPhone
            );

            return ObjectMapper.Map<SupplierMaster, SupplierMasterDto>(supplierMaster);
        }

        [Authorize(CommonServicePermissions.SupplierMasters.Edit)]
        public virtual async Task<SupplierMasterDto> UpdateAsync(int id, SupplierMasterUpdateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }
            if (input.SupplierServiceTypeId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["SupplierServiceType"]]);
            }

            var supplierMaster = await _supplierMasterManager.UpdateAsync(
            id,
            input.CountryId, input.SupplierServiceTypeId, input.Name, input.Type, input.ContactName, input.SupplierStatus, input.Preffered, input.ContactEmail, input.DialCode, input.ContactPhone, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<SupplierMaster, SupplierMasterDto>(supplierMaster);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SupplierMasterExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var supplierMasters = await _supplierMasterRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Name, input.Type, input.ContactName, input.ContactEmail, input.DialCode, input.ContactPhone, input.SupplierStatus, input.Preffered, input.CountryId, input.SupplierServiceTypeId);
            var items = supplierMasters.Select(item => new
            {
                Name = item.SupplierMaster.Name,
                Type = item.SupplierMaster.Type,
                ContactName = item.SupplierMaster.ContactName,
                ContactEmail = item.SupplierMaster.ContactEmail,
                DialCode = item.SupplierMaster.DialCode,
                ContactPhone = item.SupplierMaster.ContactPhone,
                SupplierStatus = item.SupplierMaster.SupplierStatus,
                Preffered = item.SupplierMaster.Preffered,

                Country = item.Country?.Name,
                SupplierServiceType = item.SupplierServiceType?.Name,

            });

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(items);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SupplierMasters.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.SupplierMasters.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> suppliermasterIds)
        {
            await _supplierMasterRepository.DeleteManyAsync(suppliermasterIds);
        }

        [Authorize(CommonServicePermissions.SupplierMasters.Delete)]
        public virtual async Task DeleteAllAsync(GetSupplierMastersInput input)
        {
            await _supplierMasterRepository.DeleteAllAsync(input.FilterText, input.Name, input.Type, input.ContactName, input.ContactEmail, input.DialCode, input.ContactPhone, input.SupplierStatus, input.Preffered, input.CountryId, input.SupplierServiceTypeId);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new SupplierMasterDownloadTokenCacheItem { Token = token },
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