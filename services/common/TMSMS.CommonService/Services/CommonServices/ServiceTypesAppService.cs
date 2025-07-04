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
    [Authorize(CommonServicePermissions.ServiceTypes.Default)]
    public abstract class ServiceTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<ServiceTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IServiceTypeRepository _serviceTypeRepository;
        protected ServiceTypeManager _serviceTypeManager;

        public ServiceTypesAppServiceBase(IServiceTypeRepository serviceTypeRepository, ServiceTypeManager serviceTypeManager, IDistributedCache<ServiceTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _serviceTypeRepository = serviceTypeRepository;
            _serviceTypeManager = serviceTypeManager;

        }

        public virtual async Task<PagedResultDto<ServiceTypeDto>> GetListAsync(GetServiceTypesInput input)
        {
            var totalCount = await _serviceTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _serviceTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ServiceTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ServiceType>, List<ServiceTypeDto>>(items)
            };
        }

        public virtual async Task<ServiceTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<ServiceType, ServiceTypeDto>(await _serviceTypeRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.ServiceTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _serviceTypeRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.ServiceTypes.Create)]
        public virtual async Task<ServiceTypeDto> CreateAsync(ServiceTypeCreateDto input)
        {

            var serviceType = await _serviceTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<ServiceType, ServiceTypeDto>(serviceType);
        }

        [Authorize(CommonServicePermissions.ServiceTypes.Edit)]
        public virtual async Task<ServiceTypeDto> UpdateAsync(int id, ServiceTypeUpdateDto input)
        {

            var serviceType = await _serviceTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ServiceType, ServiceTypeDto>(serviceType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ServiceTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _serviceTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ServiceType>, List<ServiceTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ServiceTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.ServiceTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> servicetypeIds)
        {
            await _serviceTypeRepository.DeleteManyAsync(servicetypeIds);
        }

        [Authorize(CommonServicePermissions.ServiceTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetServiceTypesInput input)
        {
            await _serviceTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new ServiceTypeDownloadTokenCacheItem { Token = token },
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