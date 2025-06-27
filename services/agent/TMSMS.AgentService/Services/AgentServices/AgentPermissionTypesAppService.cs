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
    [Authorize(AgentServicePermissions.AgentPermissionTypes.Default)]
    public abstract class AgentPermissionTypesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<AgentPermissionTypeDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IAgentPermissionTypeRepository _agentPermissionTypeRepository;
        protected AgentPermissionTypeManager _agentPermissionTypeManager;

        public AgentPermissionTypesAppServiceBase(IAgentPermissionTypeRepository agentPermissionTypeRepository, AgentPermissionTypeManager agentPermissionTypeManager, IDistributedCache<AgentPermissionTypeDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _agentPermissionTypeRepository = agentPermissionTypeRepository;
            _agentPermissionTypeManager = agentPermissionTypeManager;

        }

        public virtual async Task<PagedResultDto<AgentPermissionTypeDto>> GetListAsync(GetAgentPermissionTypesInput input)
        {
            var totalCount = await _agentPermissionTypeRepository.GetCountAsync(input.FilterText, input.Name, input.Description);
            var items = await _agentPermissionTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AgentPermissionTypeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgentPermissionType>, List<AgentPermissionTypeDto>>(items)
            };
        }

        public virtual async Task<AgentPermissionTypeDto> GetAsync(int id)
        {
            return ObjectMapper.Map<AgentPermissionType, AgentPermissionTypeDto>(await _agentPermissionTypeRepository.GetAsync(id));
        }

        [Authorize(AgentServicePermissions.AgentPermissionTypes.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _agentPermissionTypeRepository.DeleteAsync(id);
        }

        [Authorize(AgentServicePermissions.AgentPermissionTypes.Create)]
        public virtual async Task<AgentPermissionTypeDto> CreateAsync(AgentPermissionTypeCreateDto input)
        {

            var agentPermissionType = await _agentPermissionTypeManager.CreateAsync(
            input.Name, input.Description
            );

            return ObjectMapper.Map<AgentPermissionType, AgentPermissionTypeDto>(agentPermissionType);
        }

        [Authorize(AgentServicePermissions.AgentPermissionTypes.Edit)]
        public virtual async Task<AgentPermissionTypeDto> UpdateAsync(int id, AgentPermissionTypeUpdateDto input)
        {

            var agentPermissionType = await _agentPermissionTypeManager.UpdateAsync(
            id,
            input.Name, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<AgentPermissionType, AgentPermissionTypeDto>(agentPermissionType);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentPermissionTypeExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _agentPermissionTypeRepository.GetListAsync(input.FilterText, input.Name, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<AgentPermissionType>, List<AgentPermissionTypeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "AgentPermissionTypes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AgentServicePermissions.AgentPermissionTypes.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> agentpermissiontypeIds)
        {
            await _agentPermissionTypeRepository.DeleteManyAsync(agentpermissiontypeIds);
        }

        [Authorize(AgentServicePermissions.AgentPermissionTypes.Delete)]
        public virtual async Task DeleteAllAsync(GetAgentPermissionTypesInput input)
        {
            await _agentPermissionTypeRepository.DeleteAllAsync(input.FilterText, input.Name, input.Description);
        }
        public virtual async Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new AgentPermissionTypeDownloadTokenCacheItem { Token = token },
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