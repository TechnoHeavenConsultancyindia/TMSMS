using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class GetPromoCodeMastersInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? PromoCode { get; set; }
        public string? ServiceType { get; set; }
        public string? DiscountType { get; set; }
        public decimal? DiscountValueMin { get; set; }
        public decimal? DiscountValueMax { get; set; }
        public DateTime? DateEffectiveFromMin { get; set; }
        public DateTime? DateEffectiveFromMax { get; set; }
        public DateTime? DateEffectiveToMin { get; set; }
        public DateTime? DateEffectiveToMax { get; set; }
        public int? MaxUsageLimitMin { get; set; }
        public int? MaxUsageLimitMax { get; set; }
        public int? MaxUsagePerUserMin { get; set; }
        public int? MaxUsagePerUserMax { get; set; }
        public string? CustomerType { get; set; }
        public decimal? MinBookingAmountMin { get; set; }
        public decimal? MinBookingAmountMax { get; set; }
        public string? PaymentMethod { get; set; }
        public string? UserGroup { get; set; }
        public int? MinNoOfNightsMin { get; set; }
        public int? MinNoOfNightsMax { get; set; }
        public int? MinNoOfPaxMin { get; set; }
        public int? MinNoOfPaxMax { get; set; }
        public int? EarlyBirdDaysMin { get; set; }
        public int? EarlyBirdDaysMax { get; set; }
        public DateTime? ValidTimeFromMin { get; set; }
        public DateTime? ValidTimeFromMax { get; set; }
        public DateTime? ValidTimeToMin { get; set; }
        public DateTime? ValidTimeToMax { get; set; }
        public bool? Stackable { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }

        public GetPromoCodeMastersInputBase()
        {

        }
    }
}