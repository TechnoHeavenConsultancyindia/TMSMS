using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeMasterExcelDtoBase
    {
        public string Name { get; set; } = null!;
        public string? PromoCode { get; set; }
        public string? ServiceType { get; set; }
        public string? DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime DateEffectiveFrom { get; set; }
        public DateTime DateEffectiveTo { get; set; }
        public int? MaxUsageLimit { get; set; }
        public int? MaxUsagePerUser { get; set; }
        public string? CustomerType { get; set; }
        public decimal MinBookingAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? UserGroup { get; set; }
        public int MinNoOfNights { get; set; }
        public int MinNoOfPax { get; set; }
        public int EarlyBirdDays { get; set; }
        public DateTime ValidTimeFrom { get; set; }
        public DateTime ValidTimeTo { get; set; }
        public bool Stackable { get; set; }
    }
}