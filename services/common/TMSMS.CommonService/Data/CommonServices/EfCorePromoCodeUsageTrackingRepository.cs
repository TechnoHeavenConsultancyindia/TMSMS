using TMSMS.CommonService.CommonServices;
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
    public abstract class EfCorePromoCodeUsageTrackingRepositoryBase : EfCoreRepository<CommonServiceDbContext, PromoCodeUsageTracking, int>
    {
        public EfCorePromoCodeUsageTrackingRepositoryBase(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();

            query = ApplyFilter(query, filterText, userIDMin, userIDMax, bookingIDMin, bookingIDMax, usageDateMin, usageDateMax, promoCodeMasterId);

            var ids = query.Select(x => x.PromoCodeUsageTracking.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<PromoCodeUsageTrackingWithNavigationProperties> GetWithNavigationPropertiesAsync(int id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(promoCodeUsageTracking => new PromoCodeUsageTrackingWithNavigationProperties
                {
                    PromoCodeUsageTracking = promoCodeUsageTracking,
                    PromoCodeMaster = dbContext.Set<PromoCodeMaster>().FirstOrDefault(c => c.Id == promoCodeUsageTracking.PromoCodeMasterId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<PromoCodeUsageTrackingWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, userIDMin, userIDMax, bookingIDMin, bookingIDMax, usageDateMin, usageDateMax, promoCodeMasterId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PromoCodeUsageTrackingConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<PromoCodeUsageTrackingWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from promoCodeUsageTracking in (await GetDbSetAsync())
                   join promoCodeMaster in (await GetDbContextAsync()).Set<PromoCodeMaster>() on promoCodeUsageTracking.PromoCodeMasterId equals promoCodeMaster.Id into promoCodeMasters
                   from promoCodeMaster in promoCodeMasters.DefaultIfEmpty()
                   select new PromoCodeUsageTrackingWithNavigationProperties
                   {
                       PromoCodeUsageTracking = promoCodeUsageTracking,
                       PromoCodeMaster = promoCodeMaster
                   };
        }

        protected virtual IQueryable<PromoCodeUsageTrackingWithNavigationProperties> ApplyFilter(
            IQueryable<PromoCodeUsageTrackingWithNavigationProperties> query,
            string? filterText,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(userIDMin.HasValue, e => e.PromoCodeUsageTracking.UserID >= userIDMin!.Value)
                    .WhereIf(userIDMax.HasValue, e => e.PromoCodeUsageTracking.UserID <= userIDMax!.Value)
                    .WhereIf(bookingIDMin.HasValue, e => e.PromoCodeUsageTracking.BookingID >= bookingIDMin!.Value)
                    .WhereIf(bookingIDMax.HasValue, e => e.PromoCodeUsageTracking.BookingID <= bookingIDMax!.Value)
                    .WhereIf(usageDateMin.HasValue, e => e.PromoCodeUsageTracking.UsageDate >= usageDateMin!.Value)
                    .WhereIf(usageDateMax.HasValue, e => e.PromoCodeUsageTracking.UsageDate <= usageDateMax!.Value)
                    .WhereIf(promoCodeMasterId != null, e => e.PromoCodeMaster != null && e.PromoCodeMaster.Id == promoCodeMasterId);
        }

        public virtual async Task<List<PromoCodeUsageTracking>> GetListAsync(
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userIDMin, userIDMax, bookingIDMin, bookingIDMax, usageDateMin, usageDateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PromoCodeUsageTrackingConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, userIDMin, userIDMax, bookingIDMin, bookingIDMax, usageDateMin, usageDateMax, promoCodeMasterId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<PromoCodeUsageTracking> ApplyFilter(
            IQueryable<PromoCodeUsageTracking> query,
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(userIDMin.HasValue, e => e.UserID >= userIDMin!.Value)
                    .WhereIf(userIDMax.HasValue, e => e.UserID <= userIDMax!.Value)
                    .WhereIf(bookingIDMin.HasValue, e => e.BookingID >= bookingIDMin!.Value)
                    .WhereIf(bookingIDMax.HasValue, e => e.BookingID <= bookingIDMax!.Value)
                    .WhereIf(usageDateMin.HasValue, e => e.UsageDate >= usageDateMin!.Value)
                    .WhereIf(usageDateMax.HasValue, e => e.UsageDate <= usageDateMax!.Value);
        }
    }
}