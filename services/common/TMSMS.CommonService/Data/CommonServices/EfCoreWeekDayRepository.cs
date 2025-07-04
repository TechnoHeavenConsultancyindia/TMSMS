using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.CommonService.Data;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class EfCoreWeekDayRepositoryBase : EfCoreRepository<CommonServiceDbContext, WeekDay, int>
    {
        public EfCoreWeekDayRepositoryBase(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            string? dayAbbreviation = null,
            bool? isWeekend = null,
            int? displayOrderMin = null,
            int? displayOrderMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, name, dayAbbreviation, isWeekend, displayOrderMin, displayOrderMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<WeekDay>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? dayAbbreviation = null,
            bool? isWeekend = null,
            int? displayOrderMin = null,
            int? displayOrderMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, dayAbbreviation, isWeekend, displayOrderMin, displayOrderMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? WeekDayConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? dayAbbreviation = null,
            bool? isWeekend = null,
            int? displayOrderMin = null,
            int? displayOrderMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, dayAbbreviation, isWeekend, displayOrderMin, displayOrderMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<WeekDay> ApplyFilter(
            IQueryable<WeekDay> query,
            string? filterText = null,
            string? name = null,
            string? dayAbbreviation = null,
            bool? isWeekend = null,
            int? displayOrderMin = null,
            int? displayOrderMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.DayAbbreviation!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(dayAbbreviation), e => e.DayAbbreviation.Contains(dayAbbreviation))
                    .WhereIf(isWeekend.HasValue, e => e.IsWeekend == isWeekend)
                    .WhereIf(displayOrderMin.HasValue, e => e.DisplayOrder >= displayOrderMin!.Value)
                    .WhereIf(displayOrderMax.HasValue, e => e.DisplayOrder <= displayOrderMax!.Value);
        }
    }
}