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
    [Authorize(CommonServicePermissions.SupplierServiceTypes.Default)]
    public abstract class SupplierServiceTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<SupplierServiceTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ISupplierServiceTypeRepository _supplierServiceTypeRepository;
        protected SupplierServiceTypeManager _supplierServiceTypeManager;

        public SupplierServiceTypesAppServiceBase(ISupplierServiceTypeRepository supplierServiceTypeRepository, SupplierServiceTypeManager supplierServiceTypeManager, IDistributedCache<SupplierServiceTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _supplierServiceTypeRepository = supplierServiceTypeRepository;
            _supplierServiceTypeManager = supplierServiceTypeManager;

        }

        public virtual async Task<PagedResultDto<SupplierServiceTypeDto>> GetListAsync(GetSupplierServiceTypesInput input)
        {
            var totalCount = await _supplierServiceTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _supplierServiceTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SupplierServiceTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SupplierServiceType>, List<SupplierServiceTypeDto>>(items)
            };
        }

        public virtual async Task<SupplierServiceTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<SupplierServiceType, SupplierServiceTypeDto>(await _supplierServiceTypeRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.SupplierServiceTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _supplierServiceTypeRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.SupplierServiceTypes.Create)]
        public virtual async Task<SupplierServiceTypeDto> CreateAsync(SupplierServiceTypeCreateDto input)
        {

            var supplierServiceType = await _supplierServiceTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<SupplierServiceType, SupplierServiceTypeDto>(supplierServiceType);
        }

        [Authorize(CommonServicePermissions.SupplierServiceTypes.Edit)]
        public virtual async Task<SupplierServiceTypeDto> UpdateAsync(int id, SupplierServiceTypeUpdateDto input)
        {

            var supplierServiceType = await _supplierServiceTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<SupplierServiceType, SupplierServiceTypeDto>(supplierServiceType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SupplierServiceTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _supplierServiceTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SupplierServiceType>, List<SupplierServiceTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SupplierServiceTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.SupplierServiceTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> supplierservicetypeIds)
        {
            await _supplierServiceTypeRepository.DeleteManyAsync(supplierservicetypeIds);
        }

        [Authorize(CommonServicePermissions.SupplierServiceTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetSupplierServiceTypesInput input)
        {
            await _supplierServiceTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new SupplierServiceTypeDownloadTokenCacheItem { Token = token },
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