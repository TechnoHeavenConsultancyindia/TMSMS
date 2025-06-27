using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.AgentService.Data;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class EfCoreAgentFinanceDetailRepositoryBase : EfCoreRepository<AgentServiceDbContext, AgentFinanceDetail, int>
    {
        public EfCoreAgentFinanceDetailRepositoryBase(IDbContextProvider<AgentServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
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
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, creditLimitMin, creditLimitMax, creditLimitCurrency, displayCurrency, outstandingBalanceMin, outstandingBalanceMax, convertedBalanceMin, convertedBalanceMax, lastConversionRateMin, lastConversionRateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<AgentFinanceDetail>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, creditLimitMin, creditLimitMax, creditLimitCurrency, displayCurrency, outstandingBalanceMin, outstandingBalanceMax, convertedBalanceMin, convertedBalanceMax, lastConversionRateMin, lastConversionRateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AgentFinanceDetailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, creditLimitMin, creditLimitMax, creditLimitCurrency, displayCurrency, outstandingBalanceMin, outstandingBalanceMax, convertedBalanceMin, convertedBalanceMax, lastConversionRateMin, lastConversionRateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AgentFinanceDetail> ApplyFilter(
            IQueryable<AgentFinanceDetail> query,
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
            decimal? lastConversionRateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CreditLimitCurrency!.Contains(filterText!) || e.DisplayCurrency!.Contains(filterText!))
                    .WhereIf(creditLimitMin.HasValue, e => e.CreditLimit >= creditLimitMin!.Value)
                    .WhereIf(creditLimitMax.HasValue, e => e.CreditLimit <= creditLimitMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(creditLimitCurrency), e => e.CreditLimitCurrency.Contains(creditLimitCurrency))
                    .WhereIf(!string.IsNullOrWhiteSpace(displayCurrency), e => e.DisplayCurrency.Contains(displayCurrency))
                    .WhereIf(outstandingBalanceMin.HasValue, e => e.OutstandingBalance >= outstandingBalanceMin!.Value)
                    .WhereIf(outstandingBalanceMax.HasValue, e => e.OutstandingBalance <= outstandingBalanceMax!.Value)
                    .WhereIf(convertedBalanceMin.HasValue, e => e.ConvertedBalance >= convertedBalanceMin!.Value)
                    .WhereIf(convertedBalanceMax.HasValue, e => e.ConvertedBalance <= convertedBalanceMax!.Value)
                    .WhereIf(lastConversionRateMin.HasValue, e => e.LastConversionRate >= lastConversionRateMin!.Value)
                    .WhereIf(lastConversionRateMax.HasValue, e => e.LastConversionRate <= lastConversionRateMax!.Value);
        }
    }
}