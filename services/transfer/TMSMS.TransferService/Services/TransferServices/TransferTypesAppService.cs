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
using TMSMS.TransferService.Permissions;
using TMSMS.TransferService.TransferServices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TMSMS.TransferService.Shared;

namespace TMSMS.TransferService.TransferServices
{
    [RemoteService(IsEnabled = false)]
    [Authorize(TransferServicePermissions.TransferTypes.Default)]
    public abstract class TransferTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<TransferTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITransferTypeRepository _transferTypeRepository;
        protected TransferTypeManager _transferTypeManager;

        public TransferTypesAppServiceBase(ITransferTypeRepository transferTypeRepository, TransferTypeManager transferTypeManager, IDistributedCache<TransferTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _transferTypeRepository = transferTypeRepository;
            _transferTypeManager = transferTypeManager;

        }

        public virtual async Task<PagedResultDto<TransferTypeDto>> GetListAsync(GetTransferTypesInput input)
        {
            var totalCount = await _transferTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _transferTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TransferTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TransferType>, List<TransferTypeDto>>(items)
            };
        }

        public virtual async Task<TransferTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<TransferType, TransferTypeDto>(await _transferTypeRepository.GetAsync(id));
        }

        [Authorize(TransferServicePermissions.TransferTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _transferTypeRepository.DeleteAsync(id);
        }

        [Authorize(TransferServicePermissions.TransferTypes.Create)]
        public virtual async Task<TransferTypeDto> CreateAsync(TransferTypeCreateDto input)
        {

            var transferType = await _transferTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<TransferType, TransferTypeDto>(transferType);
        }

        [Authorize(TransferServicePermissions.TransferTypes.Edit)]
        public virtual async Task<TransferTypeDto> UpdateAsync(int id, TransferTypeUpdateDto input)
        {

            var transferType = await _transferTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<TransferType, TransferTypeDto>(transferType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TransferTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _transferTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TransferType>, List<TransferTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "TransferTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(TransferServicePermissions.TransferTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> transfertypeIds)
        {
            await _transferTypeRepository.DeleteManyAsync(transfertypeIds);
        }

        [Authorize(TransferServicePermissions.TransferTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetTransferTypesInput input)
        {
            await _transferTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.TransferService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TransferTypeDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TMSMS.TransferService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}