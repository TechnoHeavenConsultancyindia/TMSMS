using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeMasterManagerBase : DomainService
    {
        protected IPromoCodeMasterRepository _promoCodeMasterRepository;
        protected IRepository<Country, int> _countryRepository;
        protected IRepository<City, int> _cityRepository;

        public PromoCodeMasterManagerBase(IPromoCodeMasterRepository promoCodeMasterRepository,
        IRepository<Country, int> countryRepository,
        IRepository<City, int> cityRepository)
        {
            _promoCodeMasterRepository = promoCodeMasterRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        public virtual async Task<PromoCodeMaster> CreateAsync(
        List<int> countryIds,
        List<int> cityIds,
        string name, decimal discountValue, DateTime dateEffectiveFrom, DateTime dateEffectiveTo, decimal minBookingAmount, int minNoOfNights, int minNoOfPax, int earlyBirdDays, DateTime validTimeFrom, DateTime validTimeTo, bool stackable, string? promoCode = null, string? serviceType = null, string? discountType = null, int? maxUsageLimit = null, int? maxUsagePerUser = null, string? customerType = null, string? paymentMethod = null, string? userGroup = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), PromoCodeMasterConsts.NameMaxLength);
            Check.NotNull(dateEffectiveFrom, nameof(dateEffectiveFrom));
            Check.NotNull(dateEffectiveTo, nameof(dateEffectiveTo));
            Check.NotNull(validTimeFrom, nameof(validTimeFrom));
            Check.NotNull(validTimeTo, nameof(validTimeTo));
            Check.Length(promoCode, nameof(promoCode), PromoCodeMasterConsts.PromoCodeMaxLength);
            Check.Length(serviceType, nameof(serviceType), PromoCodeMasterConsts.ServiceTypeMaxLength);
            Check.Length(discountType, nameof(discountType), PromoCodeMasterConsts.DiscountTypeMaxLength);
            Check.Length(customerType, nameof(customerType), PromoCodeMasterConsts.CustomerTypeMaxLength);
            Check.Length(paymentMethod, nameof(paymentMethod), PromoCodeMasterConsts.PaymentMethodMaxLength);
            Check.Length(userGroup, nameof(userGroup), PromoCodeMasterConsts.UserGroupMaxLength);

            var promoCodeMaster = new PromoCodeMaster(

             name, discountValue, dateEffectiveFrom, dateEffectiveTo, minBookingAmount, minNoOfNights, minNoOfPax, earlyBirdDays, validTimeFrom, validTimeTo, stackable, promoCode, serviceType, discountType, maxUsageLimit, maxUsagePerUser, customerType, paymentMethod, userGroup
             );

            await SetCountriesAsync(promoCodeMaster, countryIds);
            await SetCitiesAsync(promoCodeMaster, cityIds);

            return await _promoCodeMasterRepository.InsertAsync(promoCodeMaster);
        }

        public virtual async Task<PromoCodeMaster> UpdateAsync(
            int id,
            List<int> countryIds,
        List<int> cityIds,
        string name, decimal discountValue, DateTime dateEffectiveFrom, DateTime dateEffectiveTo, decimal minBookingAmount, int minNoOfNights, int minNoOfPax, int earlyBirdDays, DateTime validTimeFrom, DateTime validTimeTo, bool stackable, string? promoCode = null, string? serviceType = null, string? discountType = null, int? maxUsageLimit = null, int? maxUsagePerUser = null, string? customerType = null, string? paymentMethod = null, string? userGroup = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), PromoCodeMasterConsts.NameMaxLength);
            Check.NotNull(dateEffectiveFrom, nameof(dateEffectiveFrom));
            Check.NotNull(dateEffectiveTo, nameof(dateEffectiveTo));
            Check.NotNull(validTimeFrom, nameof(validTimeFrom));
            Check.NotNull(validTimeTo, nameof(validTimeTo));
            Check.Length(promoCode, nameof(promoCode), PromoCodeMasterConsts.PromoCodeMaxLength);
            Check.Length(serviceType, nameof(serviceType), PromoCodeMasterConsts.ServiceTypeMaxLength);
            Check.Length(discountType, nameof(discountType), PromoCodeMasterConsts.DiscountTypeMaxLength);
            Check.Length(customerType, nameof(customerType), PromoCodeMasterConsts.CustomerTypeMaxLength);
            Check.Length(paymentMethod, nameof(paymentMethod), PromoCodeMasterConsts.PaymentMethodMaxLength);
            Check.Length(userGroup, nameof(userGroup), PromoCodeMasterConsts.UserGroupMaxLength);

            var queryable = await _promoCodeMasterRepository.WithDetailsAsync(x => x.Countries, x => x.Cities);
            var query = queryable.Where(x => x.Id == id);

            var promoCodeMaster = await AsyncExecuter.FirstOrDefaultAsync(query);

            promoCodeMaster.Name = name;
            promoCodeMaster.DiscountValue = discountValue;
            promoCodeMaster.DateEffectiveFrom = dateEffectiveFrom;
            promoCodeMaster.DateEffectiveTo = dateEffectiveTo;
            promoCodeMaster.MinBookingAmount = minBookingAmount;
            promoCodeMaster.MinNoOfNights = minNoOfNights;
            promoCodeMaster.MinNoOfPax = minNoOfPax;
            promoCodeMaster.EarlyBirdDays = earlyBirdDays;
            promoCodeMaster.ValidTimeFrom = validTimeFrom;
            promoCodeMaster.ValidTimeTo = validTimeTo;
            promoCodeMaster.Stackable = stackable;
            promoCodeMaster.PromoCode = promoCode;
            promoCodeMaster.ServiceType = serviceType;
            promoCodeMaster.DiscountType = discountType;
            promoCodeMaster.MaxUsageLimit = maxUsageLimit;
            promoCodeMaster.MaxUsagePerUser = maxUsagePerUser;
            promoCodeMaster.CustomerType = customerType;
            promoCodeMaster.PaymentMethod = paymentMethod;
            promoCodeMaster.UserGroup = userGroup;

            await SetCountriesAsync(promoCodeMaster, countryIds);
            await SetCitiesAsync(promoCodeMaster, cityIds);

            promoCodeMaster.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _promoCodeMasterRepository.UpdateAsync(promoCodeMaster);
        }

        private async Task SetCountriesAsync(PromoCodeMaster promoCodeMaster, List<int> countryIds)
        {
            if (countryIds == null || !countryIds.Any())
            {
                promoCodeMaster.RemoveAllCountries();
                return;
            }

            var query = (await _countryRepository.GetQueryableAsync())
                .Where(x => countryIds.Contains(x.Id))
                .Select(x => x.Id);

            var countryIdsInDb = await AsyncExecuter.ToListAsync(query);
            if (!countryIdsInDb.Any())
            {
                return;
            }

            promoCodeMaster.RemoveAllCountriesExceptGivenIds(countryIdsInDb);

            foreach (var countryId in countryIdsInDb)
            {
                promoCodeMaster.AddCountry(countryId);
            }
        }

        private async Task SetCitiesAsync(PromoCodeMaster promoCodeMaster, List<int> cityIds)
        {
            if (cityIds == null || !cityIds.Any())
            {
                promoCodeMaster.RemoveAllCities();
                return;
            }

            var query = (await _cityRepository.GetQueryableAsync())
                .Where(x => cityIds.Contains(x.Id))
                .Select(x => x.Id);

            var cityIdsInDb = await AsyncExecuter.ToListAsync(query);
            if (!cityIdsInDb.Any())
            {
                return;
            }

            promoCodeMaster.RemoveAllCitiesExceptGivenIds(cityIdsInDb);

            foreach (var cityId in cityIdsInDb)
            {
                promoCodeMaster.AddCity(cityId);
            }
        }

    }
}