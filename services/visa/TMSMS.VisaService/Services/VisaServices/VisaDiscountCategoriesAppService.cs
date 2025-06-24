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
    [Authorize(VisaServicePermissions.VisaDiscountCategories.Default)]
    public abstract class VisaDiscountCategoriesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<VisaDiscountCategoryDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IVisaDiscountCategoryRepository _visaDiscountCategoryRepository;
        protected VisaDiscountCategoryManager _visaDiscountCategoryManager;

        public VisaDiscountCategoriesAppServiceBase(IVisaDiscountCategoryRepository visaDiscountCategoryRepository, VisaDiscountCategoryManager visaDiscountCategoryManager, IDistributedCache<VisaDiscountCategoryDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _visaDiscountCategoryRepository = visaDiscountCategoryRepository;
            _visaDiscountCategoryManager = visaDiscountCategoryManager;

        }

        public virtual async Task<PagedResultDto<VisaDiscountCategoryDto>> GetListAsync(GetVisaDiscountCategoriesInput input)
        {
            var totalCount = await _visaDiscountCategoryRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _visaDiscountCategoryRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<VisaDiscountCategoryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<VisaDiscountCategory>, List<VisaDiscountCategoryDto>>(items)
            };
        }

        public virtual async Task<VisaDiscountCategoryDto> GetAsync(int id)
        {
            return ObjectMapper.Map<VisaDiscountCategory, VisaDiscountCategoryDto>(await _visaDiscountCategoryRepository.GetAsync(id));
        }

        [Authorize(VisaServicePermissions.VisaDiscountCategories.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _visaDiscountCategoryRepository.DeleteAsync(id);
        }

        [Authorize(VisaServicePermissions.VisaDiscountCategories.Create)]
        public virtual async Task<VisaDiscountCategoryDto> CreateAsync(VisaDiscountCategoryCreateDto input)
        {

            var visaDiscountCategory = await _visaDiscountCategoryManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<VisaDiscountCategory, VisaDiscountCategoryDto>(visaDiscountCategory);
        }

        [Authorize(VisaServicePermissions.VisaDiscountCategories.Edit)]
        public virtual async Task<VisaDiscountCategoryDto> UpdateAsync(int id, VisaDiscountCategoryUpdateDto input)
        {

            var visaDiscountCategory = await _visaDiscountCategoryManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<VisaDiscountCategory, VisaDiscountCategoryDto>(visaDiscountCategory);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(VisaDiscountCategoryExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _visaDiscountCategoryRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<VisaDiscountCategory>, List<VisaDiscountCategoryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "VisaDiscountCategories.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(VisaServicePermissions.VisaDiscountCategories.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> visadiscountcategoryIds)
        {
            await _visaDiscountCategoryRepository.DeleteManyAsync(visadiscountcategoryIds);
        }

        [Authorize(VisaServicePermissions.VisaDiscountCategories.Delete)]
        public virtual async Task DeleteAllAsync(GetVisaDiscountCategoriesInput input)
        {
            await _visaDiscountCategoryRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.VisaService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new VisaDiscountCategoryDownloadTokenCacheItem { Token = token },
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