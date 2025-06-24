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
    [Authorize(VisaServicePermissions.VisaTermCategories.Default)]
    public abstract class VisaTermCategoriesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<VisaTermCategoryDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IVisaTermCategoryRepository _visaTermCategoryRepository;
        protected VisaTermCategoryManager _visaTermCategoryManager;

        public VisaTermCategoriesAppServiceBase(IVisaTermCategoryRepository visaTermCategoryRepository, VisaTermCategoryManager visaTermCategoryManager, IDistributedCache<VisaTermCategoryDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _visaTermCategoryRepository = visaTermCategoryRepository;
            _visaTermCategoryManager = visaTermCategoryManager;

        }

        public virtual async Task<PagedResultDto<VisaTermCategoryDto>> GetListAsync(GetVisaTermCategoriesInput input)
        {
            var totalCount = await _visaTermCategoryRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _visaTermCategoryRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<VisaTermCategoryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<VisaTermCategory>, List<VisaTermCategoryDto>>(items)
            };
        }

        public virtual async Task<VisaTermCategoryDto> GetAsync(int id)
        {
            return ObjectMapper.Map<VisaTermCategory, VisaTermCategoryDto>(await _visaTermCategoryRepository.GetAsync(id));
        }

        [Authorize(VisaServicePermissions.VisaTermCategories.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _visaTermCategoryRepository.DeleteAsync(id);
        }

        [Authorize(VisaServicePermissions.VisaTermCategories.Create)]
        public virtual async Task<VisaTermCategoryDto> CreateAsync(VisaTermCategoryCreateDto input)
        {

            var visaTermCategory = await _visaTermCategoryManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<VisaTermCategory, VisaTermCategoryDto>(visaTermCategory);
        }

        [Authorize(VisaServicePermissions.VisaTermCategories.Edit)]
        public virtual async Task<VisaTermCategoryDto> UpdateAsync(int id, VisaTermCategoryUpdateDto input)
        {

            var visaTermCategory = await _visaTermCategoryManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<VisaTermCategory, VisaTermCategoryDto>(visaTermCategory);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaTermCategoryExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _visaTermCategoryRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<VisaTermCategory>, List<VisaTermCategoryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "VisaTermCategories.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(VisaServicePermissions.VisaTermCategories.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> visatermcategoryIds)
        {
            await _visaTermCategoryRepository.DeleteManyAsync(visatermcategoryIds);
        }

        [Authorize(VisaServicePermissions.VisaTermCategories.Delete)]
        public virtual async Task DeleteAllAsync(GetVisaTermCategoriesInput input)
        {
            await _visaTermCategoryRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new VisaTermCategoryDownloadTokenCacheItem { Token = token },
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