using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeMasterCreateDtoBase
    {
        [Required]
        [StringLength(PromoCodeMasterConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        [StringLength(PromoCodeMasterConsts.PromoCodeMaxLength)]
        public string? PromoCode { get; set; }
        [StringLength(PromoCodeMasterConsts.ServiceTypeMaxLength)]
        public string? ServiceType { get; set; }
        [StringLength(PromoCodeMasterConsts.DiscountTypeMaxLength)]
        public string? DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime DateEffectiveFrom { get; set; }
        public DateTime DateEffectiveTo { get; set; }
        public int? MaxUsageLimit { get; set; }
        public int? MaxUsagePerUser { get; set; }
        [StringLength(PromoCodeMasterConsts.CustomerTypeMaxLength)]
        public string? CustomerType { get; set; }
        public decimal MinBookingAmount { get; set; }
        [StringLength(PromoCodeMasterConsts.PaymentMethodMaxLength)]
        public string? PaymentMethod { get; set; }
        [StringLength(PromoCodeMasterConsts.UserGroupMaxLength)]
        public string? UserGroup { get; set; }
        public int MinNoOfNights { get; set; }
        public int MinNoOfPax { get; set; }
        public int EarlyBirdDays { get; set; }
        public DateTime ValidTimeFrom { get; set; }
        public DateTime ValidTimeTo { get; set; }
        public bool Stackable { get; set; }
        public List<int> CountryIds { get; set; }
        public List<int> CityIds { get; set; }
    }
}