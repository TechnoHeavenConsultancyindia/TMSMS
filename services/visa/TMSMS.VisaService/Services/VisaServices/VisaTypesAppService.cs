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
using TMSMS.VisaService.Permissions;
using TMSMS.VisaService.VisaServices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TMSMS.VisaService.Shared;

namespace TMSMS.VisaService.VisaServices
{
    [RemoteService(IsEnabled = false)]
    [Authorize(VisaServicePermissions.VisaTypes.Default)]
    public abstract class VisaTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<VisaTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IVisaTypeRepository _visaTypeRepository;
        protected VisaTypeManager _visaTypeManager;

        public VisaTypesAppServiceBase(IVisaTypeRepository visaTypeRepository, VisaTypeManager visaTypeManager, IDistributedCache<VisaTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _visaTypeRepository = visaTypeRepository;
            _visaTypeManager = visaTypeManager;

        }

        public virtual async Task<PagedResultDto<VisaTypeDto>> GetListAsync(GetVisaTypesInput input)
        {
            var totalCount = await _visaTypeRepository.GetCountAsync(input.FilterText, input.Name, input.SubCategory, input.VisaPurpose, input.Description);
            var items = await _visaTypeRepository.GetListAsync(input.FilterText, input.Name, input.SubCategory, input.VisaPurpose, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<VisaTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<VisaType>, List<VisaTypeDto>>(items)
            };
        }

        public virtual async Task<VisaTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<VisaType, VisaTypeDto>(await _visaTypeRepository.GetAsync(id));
        }

        [Authorize(VisaServicePermissions.VisaTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _visaTypeRepository.DeleteAsync(id);
        }

        [Authorize(VisaServicePermissions.VisaTypes.Create)]
        public virtual async Task<VisaTypeDto> CreateAsync(VisaTypeCreateDto input)
        {

            var visaType = await _visaTypeManager.CreateAsync(
            input.Name, input.SubCategory, input.VisaPurpose, input.Description
            );

            return ObjectMapper.Map<VisaType, VisaTypeDto>(visaType);
        }

        [Authorize(VisaServicePermissions.VisaTypes.Edit)]
        public virtual async Task<VisaTypeDto> UpdateAsync(int id, VisaTypeUpdateDto input)
        {

            var visaType = await _visaTypeManager.UpdateAsync(
            id,
            input.Name, input.SubCategory, input.VisaPurpose, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<VisaType, VisaTypeDto>(visaType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _visaTypeRepository.GetListAsync(input.FilterText, input.Name, input.SubCategory, input.VisaPurpose, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<VisaType>, List<VisaTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "VisaTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(VisaServicePermissions.VisaTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> visatypeIds)
        {
            await _visaTypeRepository.DeleteManyAsync(visatypeIds);
        }

        [Authorize(VisaServicePermissions.VisaTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetVisaTypesInput input)
        {
            await _visaTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.SubCategory, input.VisaPurpose, input.Description);
        }
        public virtual async Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new VisaTypeDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TMSMS.VisaService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}