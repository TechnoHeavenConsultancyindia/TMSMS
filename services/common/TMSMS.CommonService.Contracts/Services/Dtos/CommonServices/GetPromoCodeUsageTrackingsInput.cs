using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class GetPromoCodeUsageTrackingsInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public int? UserIDMin { get; set; }
        public int? UserIDMax { get; set; }
        public int? BookingIDMin { get; set; }
        public int? BookingIDMax { get; set; }
        public DateTime? UsageDateMin { get; set; }
        public DateTime? UsageDateMax { get; set; }
        public int? PromoCodeMasterId { get; set; }

        public GetPromoCodeUsageTrackingsInputBase()
        {

        }
    }
}