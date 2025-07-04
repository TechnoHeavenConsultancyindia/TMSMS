using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;
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
    public abstract class EfCorePromoCodeMasterRepositoryBase : EfCoreRepository<CommonServiceDbContext, PromoCodeMaster, int>
    {
        public EfCorePromoCodeMasterRepositoryBase(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            string? promoCode = null,
            string? serviceType = null,
            string? discountType = null,
            decimal? discountValueMin = null,
            decimal? discountValueMax = null,
            DateTime? dateEffectiveFromMin = null,
            DateTime? dateEffectiveFromMax = null,
            DateTime? dateEffectiveToMin = null,
            DateTime? dateEffectiveToMax = null,
            int? maxUsageLimitMin = null,
            int? maxUsageLimitMax = null,
            int? maxUsagePerUserMin = null,
            int? maxUsagePerUserMax = null,
            string? customerType = null,
            decimal? minBookingAmountMin = null,
            decimal? minBookingAmountMax = null,
            string? paymentMethod = null,
            string? userGroup = null,
            int? minNoOfNightsMin = null,
            int? minNoOfNightsMax = null,
            int? minNoOfPaxMin = null,
            int? minNoOfPaxMax = null,
            int? earlyBirdDaysMin = null,
            int? earlyBirdDaysMax = null,
            DateTime? validTimeFromMin = null,
            DateTime? validTimeFromMax = null,
            DateTime? validTimeToMin = null,
            DateTime? validTimeToMax = null,
            bool? stackable = null,
            int? countryId = null,
            int? cityId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();

            query = ApplyFilter(query, filterText, name, promoCode, serviceType, discountType, discountValueMin, discountValueMax, dateEffectiveFromMin, dateEffectiveFromMax, dateEffectiveToMin, dateEffectiveToMax, maxUsageLimitMin, maxUsageLimitMax, maxUsagePerUserMin, maxUsagePerUserMax, customerType, minBookingAmountMin, minBookingAmountMax, paymentMethod, userGroup, minNoOfNightsMin, minNoOfNightsMax, minNoOfPaxMin, minNoOfPaxMax, earlyBirdDaysMin, earlyBirdDaysMax, validTimeFromMin, validTimeFromMax, validTimeToMin, validTimeToMax, stackable, countryId, cityId);

            var ids = query.Select(x => x.PromoCodeMaster.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<PromoCodeMasterWithNavigationProperties> GetWithNavigationPropertiesAsync(int id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id).Include(x => x.Countries).Include(x => x.Cities)
                .Select(promoCodeMaster => new PromoCodeMasterWithNavigationProperties
                {
                    PromoCodeMaster = promoCodeMaster,
                    Countries = (from promoCodeMasterCountries in promoCodeMaster.Countries
                                 join _country in dbContext.Set<Country>() on promoCodeMasterCountries.CountryId equals _country.Id
                                 select _country).ToList(),
                    Cities = (from promoCodeMasterCities in promoCodeMaster.Cities
                              join _city in dbContext.Set<City>() on promoCodeMasterCities.CityId equals _city.Id
                              select _city).ToList()
                }).FirstOrDefault();
        }

        public virtual async Task<List<PromoCodeMasterWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? name = null,
            string? promoCode = null,
            string? serviceType = null,
            string? discountType = null,
            decimal? discountValueMin = null,
            decimal? discountValueMax = null,
            DateTime? dateEffectiveFromMin = null,
            DateTime? dateEffectiveFromMax = null,
            DateTime? dateEffectiveToMin = null,
            DateTime? dateEffectiveToMax = null,
            int? maxUsageLimitMin = null,
            int? maxUsageLimitMax = null,
            int? maxUsagePerUserMin = null,
            int? maxUsagePerUserMax = null,
            string? customerType = null,
            decimal? minBookingAmountMin = null,
            decimal? minBookingAmountMax = null,
            string? paymentMethod = null,
            string? userGroup = null,
            int? minNoOfNightsMin = null,
            int? minNoOfNightsMax = null,
            int? minNoOfPaxMin = null,
            int? minNoOfPaxMax = null,
            int? earlyBirdDaysMin = null,
            int? earlyBirdDaysMax = null,
            DateTime? validTimeFromMin = null,
            DateTime? validTimeFromMax = null,
            DateTime? validTimeToMin = null,
            DateTime? validTimeToMax = null,
            bool? stackable = null,
            int? countryId = null,
            int? cityId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, promoCode, serviceType, discountType, discountValueMin, discountValueMax, dateEffectiveFromMin, dateEffectiveFromMax, dateEffectiveToMin, dateEffectiveToMax, maxUsageLimitMin, maxUsageLimitMax, maxUsagePerUserMin, maxUsagePerUserMax, customerType, minBookingAmountMin, minBookingAmountMax, paymentMethod, userGroup, minNoOfNightsMin, minNoOfNightsMax, minNoOfPaxMin, minNoOfPaxMax, earlyBirdDaysMin, earlyBirdDaysMax, validTimeFromMin, validTimeFromMax, validTimeToMin, validTimeToMax, stackable, countryId, cityId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PromoCodeMasterConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<PromoCodeMasterWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from promoCodeMaster in (await GetDbSetAsync())

                   select new PromoCodeMasterWithNavigationProperties
                   {
                       PromoCodeMaster = promoCodeMaster,
                       Countries = new List<Country>(),
                       Cities = new List<City>()
                   };
        }

        protected virtual IQueryable<PromoCodeMasterWithNavigationProperties> ApplyFilter(
            IQueryable<PromoCodeMasterWithNavigationProperties> query,
            string? filterText,
            string? name = null,
            string? promoCode = null,
            string? serviceType = null,
            string? discountType = null,
            decimal? discountValueMin = null,
            decimal? discountValueMax = null,
            DateTime? dateEffectiveFromMin = null,
            DateTime? dateEffectiveFromMax = null,
            DateTime? dateEffectiveToMin = null,
            DateTime? dateEffectiveToMax = null,
            int? maxUsageLimitMin = null,
            int? maxUsageLimitMax = null,
            int? maxUsagePerUserMin = null,
            int? maxUsagePerUserMax = null,
            string? customerType = null,
            decimal? minBookingAmountMin = null,
            decimal? minBookingAmountMax = null,
            string? paymentMethod = null,
            string? userGroup = null,
            int? minNoOfNightsMin = null,
            int? minNoOfNightsMax = null,
            int? minNoOfPaxMin = null,
            int? minNoOfPaxMax = null,
            int? earlyBirdDaysMin = null,
            int? earlyBirdDaysMax = null,
            DateTime? validTimeFromMin = null,
            DateTime? validTimeFromMax = null,
            DateTime? validTimeToMin = null,
            DateTime? validTimeToMax = null,
            bool? stackable = null,
            int? countryId = null,
            int? cityId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PromoCodeMaster.Name!.Contains(filterText!) || e.PromoCodeMaster.PromoCode!.Contains(filterText!) || e.PromoCodeMaster.ServiceType!.Contains(filterText!) || e.PromoCodeMaster.DiscountType!.Contains(filterText!) || e.PromoCodeMaster.CustomerType!.Contains(filterText!) || e.PromoCodeMaster.PaymentMethod!.Contains(filterText!) || e.PromoCodeMaster.UserGroup!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.PromoCodeMaster.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(promoCode), e => e.PromoCodeMaster.PromoCode.Contains(promoCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(serviceType), e => e.PromoCodeMaster.ServiceType.Contains(serviceType))
                    .WhereIf(!string.IsNullOrWhiteSpace(discountType), e => e.PromoCodeMaster.DiscountType.Contains(discountType))
                    .WhereIf(discountValueMin.HasValue, e => e.PromoCodeMaster.DiscountValue >= discountValueMin!.Value)
                    .WhereIf(discountValueMax.HasValue, e => e.PromoCodeMaster.DiscountValue <= discountValueMax!.Value)
                    .WhereIf(dateEffectiveFromMin.HasValue, e => e.PromoCodeMaster.DateEffectiveFrom >= dateEffectiveFromMin!.Value)
                    .WhereIf(dateEffectiveFromMax.HasValue, e => e.PromoCodeMaster.DateEffectiveFrom <= dateEffectiveFromMax!.Value)
                    .WhereIf(dateEffectiveToMin.HasValue, e => e.PromoCodeMaster.DateEffectiveTo >= dateEffectiveToMin!.Value)
                    .WhereIf(dateEffectiveToMax.HasValue, e => e.PromoCodeMaster.DateEffectiveTo <= dateEffectiveToMax!.Value)
                    .WhereIf(maxUsageLimitMin.HasValue, e => e.PromoCodeMaster.MaxUsageLimit >= maxUsageLimitMin!.Value)
                    .WhereIf(maxUsageLimitMax.HasValue, e => e.PromoCodeMaster.MaxUsageLimit <= maxUsageLimitMax!.Value)
                    .WhereIf(maxUsagePerUserMin.HasValue, e => e.PromoCodeMaster.MaxUsagePerUser >= maxUsagePerUserMin!.Value)
                    .WhereIf(maxUsagePerUserMax.HasValue, e => e.PromoCodeMaster.MaxUsagePerUser <= maxUsagePerUserMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(customerType), e => e.PromoCodeMaster.CustomerType.Contains(customerType))
                    .WhereIf(minBookingAmountMin.HasValue, e => e.PromoCodeMaster.MinBookingAmount >= minBookingAmountMin!.Value)
                    .WhereIf(minBookingAmountMax.HasValue, e => e.PromoCodeMaster.MinBookingAmount <= minBookingAmountMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(paymentMethod), e => e.PromoCodeMaster.PaymentMethod.Contains(paymentMethod))
                    .WhereIf(!string.IsNullOrWhiteSpace(userGroup), e => e.PromoCodeMaster.UserGroup.Contains(userGroup))
                    .WhereIf(minNoOfNightsMin.HasValue, e => e.PromoCodeMaster.MinNoOfNights >= minNoOfNightsMin!.Value)
                    .WhereIf(minNoOfNightsMax.HasValue, e => e.PromoCodeMaster.MinNoOfNights <= minNoOfNightsMax!.Value)
                    .WhereIf(minNoOfPaxMin.HasValue, e => e.PromoCodeMaster.MinNoOfPax >= minNoOfPaxMin!.Value)
                    .WhereIf(minNoOfPaxMax.HasValue, e => e.PromoCodeMaster.MinNoOfPax <= minNoOfPaxMax!.Value)
                    .WhereIf(earlyBirdDaysMin.HasValue, e => e.PromoCodeMaster.EarlyBirdDays >= earlyBirdDaysMin!.Value)
                    .WhereIf(earlyBirdDaysMax.HasValue, e => e.PromoCodeMaster.EarlyBirdDays <= earlyBirdDaysMax!.Value)
                    .WhereIf(validTimeFromMin.HasValue, e => e.PromoCodeMaster.ValidTimeFrom >= validTimeFromMin!.Value)
                    .WhereIf(validTimeFromMax.HasValue, e => e.PromoCodeMaster.ValidTimeFrom <= validTimeFromMax!.Value)
                    .WhereIf(validTimeToMin.HasValue, e => e.PromoCodeMaster.ValidTimeTo >= validTimeToMin!.Value)
                    .WhereIf(validTimeToMax.HasValue, e => e.PromoCodeMaster.ValidTimeTo <= validTimeToMax!.Value)
                    .WhereIf(stackable.HasValue, e => e.PromoCodeMaster.Stackable == stackable)
                    .WhereIf(countryId != null, e => e.PromoCodeMaster.Countries.Any(x => x.CountryId == countryId))
                    .WhereIf(cityId != null, e => e.PromoCodeMaster.Cities.Any(x => x.CityId == cityId));
        }

        public virtual async Task<List<PromoCodeMaster>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? promoCode = null,
            string? serviceType = null,
            string? discountType = null,
            decimal? discountValueMin = null,
            decimal? discountValueMax = null,
            DateTime? dateEffectiveFromMin = null,
            DateTime? dateEffectiveFromMax = null,
            DateTime? dateEffectiveToMin = null,
            DateTime? dateEffectiveToMax = null,
            int? maxUsageLimitMin = null,
            int? maxUsageLimitMax = null,
            int? maxUsagePerUserMin = null,
            int? maxUsagePerUserMax = null,
            string? customerType = null,
            decimal? minBookingAmountMin = null,
            decimal? minBookingAmountMax = null,
            string? paymentMethod = null,
            string? userGroup = null,
            int? minNoOfNightsMin = null,
            int? minNoOfNightsMax = null,
            int? minNoOfPaxMin = null,
            int? minNoOfPaxMax = null,
            int? earlyBirdDaysMin = null,
            int? earlyBirdDaysMax = null,
            DateTime? validTimeFromMin = null,
            DateTime? validTimeFromMax = null,
            DateTime? validTimeToMin = null,
            DateTime? validTimeToMax = null,
            bool? stackable = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, promoCode, serviceType, discountType, discountValueMin, discountValueMax, dateEffectiveFromMin, dateEffectiveFromMax, dateEffectiveToMin, dateEffectiveToMax, maxUsageLimitMin, maxUsageLimitMax, maxUsagePerUserMin, maxUsagePerUserMax, customerType, minBookingAmountMin, minBookingAmountMax, paymentMethod, userGroup, minNoOfNightsMin, minNoOfNightsMax, minNoOfPaxMin, minNoOfPaxMax, earlyBirdDaysMin, earlyBirdDaysMax, validTimeFromMin, validTimeFromMax, validTimeToMin, validTimeToMax, stackable);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PromoCodeMasterConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? promoCode = null,
            string? serviceType = null,
            string? discountType = null,
            decimal? discountValueMin = null,
            decimal? discountValueMax = null,
            DateTime? dateEffectiveFromMin = null,
            DateTime? dateEffectiveFromMax = null,
            DateTime? dateEffectiveToMin = null,
            DateTime? dateEffectiveToMax = null,
            int? maxUsageLimitMin = null,
            int? maxUsageLimitMax = null,
            int? maxUsagePerUserMin = null,
            int? maxUsagePerUserMax = null,
            string? customerType = null,
            decimal? minBookingAmountMin = null,
            decimal? minBookingAmountMax = null,
            string? paymentMethod = null,
            string? userGroup = null,
            int? minNoOfNightsMin = null,
            int? minNoOfNightsMax = null,
            int? minNoOfPaxMin = null,
            int? minNoOfPaxMax = null,
            int? earlyBirdDaysMin = null,
            int? earlyBirdDaysMax = null,
            DateTime? validTimeFromMin = null,
            DateTime? validTimeFromMax = null,
            DateTime? validTimeToMin = null,
            DateTime? validTimeToMax = null,
            bool? stackable = null,
            int? countryId = null,
            int? cityId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, promoCode, serviceType, discountType, discountValueMin, discountValueMax, dateEffectiveFromMin, dateEffectiveFromMax, dateEffectiveToMin, dateEffectiveToMax, maxUsageLimitMin, maxUsageLimitMax, maxUsagePerUserMin, maxUsagePerUserMax, customerType, minBookingAmountMin, minBookingAmountMax, paymentMethod, userGroup, minNoOfNightsMin, minNoOfNightsMax, minNoOfPaxMin, minNoOfPaxMax, earlyBirdDaysMin, earlyBirdDaysMax, validTimeFromMin, validTimeFromMax, validTimeToMin, validTimeToMax, stackable, countryId, cityId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<PromoCodeMaster> ApplyFilter(
            IQueryable<PromoCodeMaster> query,
            string? filterText = null,
            string? name = null,
            string? promoCode = null,
            string? serviceType = null,
            string? discountType = null,
            decimal? discountValueMin = null,
            decimal? discountValueMax = null,
            DateTime? dateEffectiveFromMin = null,
            DateTime? dateEffectiveFromMax = null,
            DateTime? dateEffectiveToMin = null,
            DateTime? dateEffectiveToMax = null,
            int? maxUsageLimitMin = null,
            int? maxUsageLimitMax = null,
            int? maxUsagePerUserMin = null,
            int? maxUsagePerUserMax = null,
            string? customerType = null,
            decimal? minBookingAmountMin = null,
            decimal? minBookingAmountMax = null,
            string? paymentMethod = null,
            string? userGroup = null,
            int? minNoOfNightsMin = null,
            int? minNoOfNightsMax = null,
            int? minNoOfPaxMin = null,
            int? minNoOfPaxMax = null,
            int? earlyBirdDaysMin = null,
            int? earlyBirdDaysMax = null,
            DateTime? validTimeFromMin = null,
            DateTime? validTimeFromMax = null,
            DateTime? validTimeToMin = null,
            DateTime? validTimeToMax = null,
            bool? stackable = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.PromoCode!.Contains(filterText!) || e.ServiceType!.Contains(filterText!) || e.DiscountType!.Contains(filterText!) || e.CustomerType!.Contains(filterText!) || e.PaymentMethod!.Contains(filterText!) || e.UserGroup!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(promoCode), e => e.PromoCode.Contains(promoCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(serviceType), e => e.ServiceType.Contains(serviceType))
                    .WhereIf(!string.IsNullOrWhiteSpace(discountType), e => e.DiscountType.Contains(discountType))
                    .WhereIf(discountValueMin.HasValue, e => e.DiscountValue >= discountValueMin!.Value)
                    .WhereIf(discountValueMax.HasValue, e => e.DiscountValue <= discountValueMax!.Value)
                    .WhereIf(dateEffectiveFromMin.HasValue, e => e.DateEffectiveFrom >= dateEffectiveFromMin!.Value)
                    .WhereIf(dateEffectiveFromMax.HasValue, e => e.DateEffectiveFrom <= dateEffectiveFromMax!.Value)
                    .WhereIf(dateEffectiveToMin.HasValue, e => e.DateEffectiveTo >= dateEffectiveToMin!.Value)
                    .WhereIf(dateEffectiveToMax.HasValue, e => e.DateEffectiveTo <= dateEffectiveToMax!.Value)
                    .WhereIf(maxUsageLimitMin.HasValue, e => e.MaxUsageLimit >= maxUsageLimitMin!.Value)
                    .WhereIf(maxUsageLimitMax.HasValue, e => e.MaxUsageLimit <= maxUsageLimitMax!.Value)
                    .WhereIf(maxUsagePerUserMin.HasValue, e => e.MaxUsagePerUser >= maxUsagePerUserMin!.Value)
                    .WhereIf(maxUsagePerUserMax.HasValue, e => e.MaxUsagePerUser <= maxUsagePerUserMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(customerType), e => e.CustomerType.Contains(customerType))
                    .WhereIf(minBookingAmountMin.HasValue, e => e.MinBookingAmount >= minBookingAmountMin!.Value)
                    .WhereIf(minBookingAmountMax.HasValue, e => e.MinBookingAmount <= minBookingAmountMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(paymentMethod), e => e.PaymentMethod.Contains(paymentMethod))
                    .WhereIf(!string.IsNullOrWhiteSpace(userGroup), e => e.UserGroup.Contains(userGroup))
                    .WhereIf(minNoOfNightsMin.HasValue, e => e.MinNoOfNights >= minNoOfNightsMin!.Value)
                    .WhereIf(minNoOfNightsMax.HasValue, e => e.MinNoOfNights <= minNoOfNightsMax!.Value)
                    .WhereIf(minNoOfPaxMin.HasValue, e => e.MinNoOfPax >= minNoOfPaxMin!.Value)
                    .WhereIf(minNoOfPaxMax.HasValue, e => e.MinNoOfPax <= minNoOfPaxMax!.Value)
                    .WhereIf(earlyBirdDaysMin.HasValue, e => e.EarlyBirdDays >= earlyBirdDaysMin!.Value)
                    .WhereIf(earlyBirdDaysMax.HasValue, e => e.EarlyBirdDays <= earlyBirdDaysMax!.Value)
                    .WhereIf(validTimeFromMin.HasValue, e => e.ValidTimeFrom >= validTimeFromMin!.Value)
                    .WhereIf(validTimeFromMax.HasValue, e => e.ValidTimeFrom <= validTimeFromMax!.Value)
                    .WhereIf(validTimeToMin.HasValue, e => e.ValidTimeTo >= validTimeToMin!.Value)
                    .WhereIf(validTimeToMax.HasValue, e => e.ValidTimeTo <= validTimeToMax!.Value)
                    .WhereIf(stackable.HasValue, e => e.Stackable == stackable);
        }
    }
}