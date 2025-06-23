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
    [Authorize(AgentServicePermissions.AgentGroupTypes.Default)]
    public abstract class AgentGroupTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<AgentGroupTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IAgentGroupTypeRepository _agentGroupTypeRepository;
        protected AgentGroupTypeManager _agentGroupTypeManager;

        public AgentGroupTypesAppServiceBase(IAgentGroupTypeRepository agentGroupTypeRepository, AgentGroupTypeManager agentGroupTypeManager, IDistributedCache<AgentGroupTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _agentGroupTypeRepository = agentGroupTypeRepository;
            _agentGroupTypeManager = agentGroupTypeManager;

        }

        public virtual async Task<PagedResultDto<AgentGroupTypeDto>> GetListAsync(GetAgentGroupTypesInput input)
        {
            var totalCount = await _agentGroupTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _agentGroupTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AgentGroupTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgentGroupType>, List<AgentGroupTypeDto>>(items)
            };
        }

        public virtual async Task<AgentGroupTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<AgentGroupType, AgentGroupTypeDto>(await _agentGroupTypeRepository.GetAsync(id));
        }

        [Authorize(AgentServicePermissions.AgentGroupTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _agentGroupTypeRepository.DeleteAsync(id);
        }

        [Authorize(AgentServicePermissions.AgentGroupTypes.Create)]
        public virtual async Task<AgentGroupTypeDto> CreateAsync(AgentGroupTypeCreateDto input)
        {

            var agentGroupType = await _agentGroupTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<AgentGroupType, AgentGroupTypeDto>(agentGroupType);
        }

        [Authorize(AgentServicePermissions.AgentGroupTypes.Edit)]
        public virtual async Task<AgentGroupTypeDto> UpdateAsync(int id, AgentGroupTypeUpdateDto input)
        {

            var agentGroupType = await _agentGroupTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<AgentGroupType, AgentGroupTypeDto>(agentGroupType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentGroupTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _agentGroupTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<AgentGroupType>, List<AgentGroupTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "AgentGroupTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AgentServicePermissions.AgentGroupTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> agentgrouptypeIds)
        {
            await _agentGroupTypeRepository.DeleteManyAsync(agentgrouptypeIds);
        }

        [Authorize(AgentServicePermissions.AgentGroupTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetAgentGroupTypesInput input)
        {
            await _agentGroupTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new AgentGroupTypeDownloadTokenCacheItem { Token = token },
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