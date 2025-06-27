using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.AgentService.AgentServices
{
    public partial interface IAgentFinanceDetailRepository : IRepository<AgentFinanceDetail, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            decimal? creditLimitMin = null,
            decimal? creditLimitMax = null,
            string? creditLimitCurrency = null,
            string? displayCurrency = null,
            decimal? outstandingBalanceMin = null,
            decimal? outstandingBalanceMax = null,
            decimal? convertedBalanceMin = null,
            decimal? convertedBalanceMax = null,
            decimal? lastConversionRateMin = null,
            decimal? lastConversionRateMax = null,
            CancellationToken cancellationToken = default);
        Task<List<AgentFinanceDetail>> GetListAsync(
                    string? filterText = null,
                    decimal? creditLimitMin = null,
                    decimal? creditLimitMax = null,
                    string? creditLimitCurrency = null,
                    string? displayCurrency = null,
                    decimal? outstandingBalanceMin = null,
                    decimal? outstandingBalanceMax = null,
                    decimal? convertedBalanceMin = null,
                    decimal? convertedBalanceMax = null,
                    decimal? lastConversionRateMin = null,
                    decimal? lastConversionRateMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            decimal? creditLimitMin = null,
            decimal? creditLimitMax = null,
            string? creditLimitCurrency = null,
            string? displayCurrency = null,
            decimal? outstandingBalanceMin = null,
            decimal? outstandingBalanceMax = null,
            decimal? convertedBalanceMin = null,
            decimal? convertedBalanceMax = null,
            decimal? lastConversionRateMin = null,
            decimal? lastConversionRateMax = null,
            CancellationToken cancellationToken = default);
    }
}