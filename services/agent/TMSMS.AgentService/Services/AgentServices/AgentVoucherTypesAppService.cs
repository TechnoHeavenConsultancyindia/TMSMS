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
using TMSMS.AgentService.Permissions;
using TMSMS.AgentService.AgentServices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TMSMS.AgentService.Shared;

namespace TMSMS.AgentService.AgentServices
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AgentServicePermissions.AgentVoucherTypes.Default)]
    public abstract class AgentVoucherTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<AgentVoucherTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IAgentVoucherTypeRepository _agentVoucherTypeRepository;
        protected AgentVoucherTypeManager _agentVoucherTypeManager;

        public AgentVoucherTypesAppServiceBase(IAgentVoucherTypeRepository agentVoucherTypeRepository, AgentVoucherTypeManager agentVoucherTypeManager, IDistributedCache<AgentVoucherTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _agentVoucherTypeRepository = agentVoucherTypeRepository;
            _agentVoucherTypeManager = agentVoucherTypeManager;

        }

        public virtual async Task<PagedResultDto<AgentVoucherTypeDto>> GetListAsync(GetAgentVoucherTypesInput input)
        {
            var totalCount = await _agentVoucherTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _agentVoucherTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AgentVoucherTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgentVoucherType>, List<AgentVoucherTypeDto>>(items)
            };
        }

        public virtual async Task<AgentVoucherTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<AgentVoucherType, AgentVoucherTypeDto>(await _agentVoucherTypeRepository.GetAsync(id));
        }

        [Authorize(AgentServicePermissions.AgentVoucherTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _agentVoucherTypeRepository.DeleteAsync(id);
        }

        [Authorize(AgentServicePermissions.AgentVoucherTypes.Create)]
        public virtual async Task<AgentVoucherTypeDto> CreateAsync(AgentVoucherTypeCreateDto input)
        {

            var agentVoucherType = await _agentVoucherTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<AgentVoucherType, AgentVoucherTypeDto>(agentVoucherType);
        }

        [Authorize(AgentServicePermissions.AgentVoucherTypes.Edit)]
        public virtual async Task<AgentVoucherTypeDto> UpdateAsync(int id, AgentVoucherTypeUpdateDto input)
        {

            var agentVoucherType = await _agentVoucherTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<AgentVoucherType, AgentVoucherTypeDto>(agentVoucherType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentVoucherTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _agentVoucherTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<AgentVoucherType>, List<AgentVoucherTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "AgentVoucherTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AgentServicePermissions.AgentVoucherTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> agentvouchertypeIds)
        {
            await _agentVoucherTypeRepository.DeleteManyAsync(agentvouchertypeIds);
        }

        [Authorize(AgentServicePermissions.AgentVoucherTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetAgentVoucherTypesInput input)
        {
            await _agentVoucherTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new AgentVoucherTypeDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TMSMS.AgentService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}