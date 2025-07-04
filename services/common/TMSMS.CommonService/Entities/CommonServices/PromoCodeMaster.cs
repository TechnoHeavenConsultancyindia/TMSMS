using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeMasterBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? PromoCode { get; set; }

        [CanBeNull]
        public virtual string? ServiceType { get; set; }

        [CanBeNull]
        public virtual string? DiscountType { get; set; }

        public virtual decimal DiscountValue { get; set; }

        public virtual DateTime DateEffectiveFrom { get; set; }

        public virtual DateTime DateEffectiveTo { get; set; }

        public virtual int? MaxUsageLimit { get; set; }

        public virtual int? MaxUsagePerUser { get; set; }

        [CanBeNull]
        public virtual string? CustomerType { get; set; }

        public virtual decimal MinBookingAmount { get; set; }

        [CanBeNull]
        public virtual string? PaymentMethod { get; set; }

        [CanBeNull]
        public virtual string? UserGroup { get; set; }

        public virtual int MinNoOfNights { get; set; }

        public virtual int MinNoOfPax { get; set; }

        public virtual int EarlyBirdDays { get; set; }

        public virtual DateTime ValidTimeFrom { get; set; }

        public virtual DateTime ValidTimeTo { get; set; }

        public virtual bool Stackable { get; set; }

        public ICollection<PromoCodeMasterCountry> Countries { get; private set; }
        public ICollection<PromoCodeMasterCity> Cities { get; private set; }

        protected PromoCodeMasterBase()
        {

        }

        public PromoCodeMasterBase(string name, decimal discountValue, DateTime dateEffectiveFrom, DateTime dateEffectiveTo, decimal minBookingAmount, int minNoOfNights, int minNoOfPax, int earlyBirdDays, DateTime validTimeFrom, DateTime validTimeTo, bool stackable, string? promoCode = null, string? serviceType = null, string? discountType = null, int? maxUsageLimit = null, int? maxUsagePerUser = null, string? customerType = null, string? paymentMethod = null, string? userGroup = null)
        {

            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), PromoCodeMasterConsts.NameMaxLength, 0);
            Check.Length(promoCode, nameof(promoCode), PromoCodeMasterConsts.PromoCodeMaxLength, 0);
            Check.Length(serviceType, nameof(serviceType), PromoCodeMasterConsts.ServiceTypeMaxLength, 0);
            Check.Length(discountType, nameof(discountType), PromoCodeMasterConsts.DiscountTypeMaxLength, 0);
            Check.Length(customerType, nameof(customerType), PromoCodeMasterConsts.CustomerTypeMaxLength, 0);
            Check.Length(paymentMethod, nameof(paymentMethod), PromoCodeMasterConsts.PaymentMethodMaxLength, 0);
            Check.Length(userGroup, nameof(userGroup), PromoCodeMasterConsts.UserGroupMaxLength, 0);
            Name = name;
            DiscountValue = discountValue;
            DateEffectiveFrom = dateEffectiveFrom;
            DateEffectiveTo = dateEffectiveTo;
            MinBookingAmount = minBookingAmount;
            MinNoOfNights = minNoOfNights;
            MinNoOfPax = minNoOfPax;
            EarlyBirdDays = earlyBirdDays;
            ValidTimeFrom = validTimeFrom;
            ValidTimeTo = validTimeTo;
            Stackable = stackable;
            PromoCode = promoCode;
            ServiceType = serviceType;
            DiscountType = discountType;
            MaxUsageLimit = maxUsageLimit;
            MaxUsagePerUser = maxUsagePerUser;
            CustomerType = customerType;
            PaymentMethod = paymentMethod;
            UserGroup = userGroup;
            Countries = new Collection<PromoCodeMasterCountry>();
            Cities = new Collection<PromoCodeMasterCity>();
        }
        public virtual void AddCountry(int countryId)
        {
            Check.NotNull(countryId, nameof(countryId));

            if (IsInCountries(countryId))
            {
                return;
            }

            Countries.Add(new PromoCodeMasterCountry(Id, countryId));
        }

        public virtual void RemoveCountry(int countryId)
        {
            Check.NotNull(countryId, nameof(countryId));

            if (!IsInCountries(countryId))
            {
                return;
            }

            Countries.RemoveAll(x => x.CountryId == countryId);
        }

        public virtual void RemoveAllCountriesExceptGivenIds(List<int> countryIds)
        {
            Check.NotNullOrEmpty(countryIds, nameof(countryIds));

            Countries.RemoveAll(x => !countryIds.Contains(x.CountryId));
        }

        public virtual void RemoveAllCountries()
        {
            Countries.RemoveAll(x => x.PromoCodeMasterId == Id);
        }

        private bool IsInCountries(int countryId)
        {
            return Countries.Any(x => x.CountryId == countryId);
        }

        public virtual void AddCity(int cityId)
        {
            Check.NotNull(cityId, nameof(cityId));

            if (IsInCities(cityId))
            {
                return;
            }

            Cities.Add(new PromoCodeMasterCity(Id, cityId));
        }

        public virtual void RemoveCity(int cityId)
        {
            Check.NotNull(cityId, nameof(cityId));

            if (!IsInCities(cityId))
            {
                return;
            }

            Cities.RemoveAll(x => x.CityId == cityId);
        }

        public virtual void RemoveAllCitiesExceptGivenIds(List<int> cityIds)
        {
            Check.NotNullOrEmpty(cityIds, nameof(cityIds));

            Cities.RemoveAll(x => !cityIds.Contains(x.CityId));
        }

        public virtual void RemoveAllCities()
        {
            Cities.RemoveAll(x => x.PromoCodeMasterId == Id);
        }

        private bool IsInCities(int cityId)
        {
            return Cities.Any(x => x.CityId == cityId);
        }
    }
}