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
    [Authorize(AgentServicePermissions.AgentFinanceDetails.Default)]
    public abstract class AgentFinanceDetailsAppServiceBase : ApplicationService
    {
        protected IDistributedCache<AgentFinanceDetailDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IAgentFinanceDetailRepository _agentFinanceDetailRepository;
        protected AgentFinanceDetailManager _agentFinanceDetailManager;

        public AgentFinanceDetailsAppServiceBase(IAgentFinanceDetailRepository agentFinanceDetailRepository, AgentFinanceDetailManager agentFinanceDetailManager, IDistributedCache<AgentFinanceDetailDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _agentFinanceDetailRepository = agentFinanceDetailRepository;
            _agentFinanceDetailManager = agentFinanceDetailManager;

        }

        public virtual async Task<PagedResultDto<AgentFinanceDetailDto>> GetListAsync(GetAgentFinanceDetailsInput input)
        {
            var totalCount = await _agentFinanceDetailRepository.GetCountAsync(input.FilterText, input.CreditLimitMin, input.CreditLimitMax, input.CreditLimitCurrency, input.DisplayCurrency, input.OutstandingBalanceMin, input.OutstandingBalanceMax, input.ConvertedBalanceMin, input.ConvertedBalanceMax, input.LastConversionRateMin, input.LastConversionRateMax);
            var items = await _agentFinanceDetailRepository.GetListAsync(input.FilterText, input.CreditLimitMin, input.CreditLimitMax, input.CreditLimitCurrency, input.DisplayCurrency, input.OutstandingBalanceMin, input.OutstandingBalanceMax, input.ConvertedBalanceMin, input.ConvertedBalanceMax, input.LastConversionRateMin, input.LastConversionRateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AgentFinanceDetailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AgentFinanceDetail>, List<AgentFinanceDetailDto>>(items)
            };
        }

        public virtual async Task<AgentFinanceDetailDto> GetAsync(int id)
        {
            return ObjectMapper.Map<AgentFinanceDetail, AgentFinanceDetailDto>(await _agentFinanceDetailRepository.GetAsync(id));
        }

        [Authorize(AgentServicePermissions.AgentFinanceDetails.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _agentFinanceDetailRepository.DeleteAsync(id);
        }

        [Authorize(AgentServicePermissions.AgentFinanceDetails.Create)]
        public virtual async Task<AgentFinanceDetailDto> CreateAsync(AgentFinanceDetailCreateDto input)
        {

            var agentFinanceDetail = await _agentFinanceDetailManager.CreateAsync(
            input.CreditLimit, input.OutstandingBalance, input.ConvertedBalance, input.LastConversionRate, input.CreditLimitCurrency, input.DisplayCurrency
            );

            return ObjectMapper.Map<AgentFinanceDetail, AgentFinanceDetailDto>(agentFinanceDetail);
        }

        [Authorize(AgentServicePermissions.AgentFinanceDetails.Edit)]
        public virtual async Task<AgentFinanceDetailDto> UpdateAsync(int id, AgentFinanceDetailUpdateDto input)
        {

            var agentFinanceDetail = await _agentFinanceDetailManager.UpdateAsync(
            id,
            input.CreditLimit, input.OutstandingBalance, input.ConvertedBalance, input.LastConversionRate, input.CreditLimitCurrency, input.DisplayCurrency, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<AgentFinanceDetail, AgentFinanceDetailDto>(agentFinanceDetail);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(AgentFinanceDetailExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _agentFinanceDetailRepository.GetListAsync(input.FilterText, input.CreditLimitMin, input.CreditLimitMax, input.CreditLimitCurrency, input.DisplayCurrency, input.OutstandingBalanceMin, input.OutstandingBalanceMax, input.ConvertedBalanceMin, input.ConvertedBalanceMax, input.LastConversionRateMin, input.LastConversionRateMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<AgentFinanceDetail>, List<AgentFinanceDetailExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "AgentFinanceDetails.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(AgentServicePermissions.AgentFinanceDetails.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> agentfinancedetailIds)
        {
            await _agentFinanceDetailRepository.DeleteManyAsync(agentfinancedetailIds);
        }

        [Authorize(AgentServicePermissions.AgentFinanceDetails.Delete)]
        public virtual async Task DeleteAllAsync(GetAgentFinanceDetailsInput input)
        {
            await _agentFinanceDetailRepository.DeleteAllAsync(input.FilterText, input.CreditLimitMin, input.CreditLimitMax, input.CreditLimitCurrency, input.DisplayCurrency, input.OutstandingBalanceMin, input.OutstandingBalanceMax, input.ConvertedBalanceMin, input.ConvertedBalanceMax, input.LastConversionRateMin, input.LastConversionRateMax);
        }
        public virtual async Task<TMSMS.AgentService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new AgentFinanceDetailDownloadTokenCacheItem { Token = token },
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