using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class PromoCodeUsageTrackingDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public int UserID { get; set; }
        public int BookingID { get; set; }
        public DateTime UsageDate { get; set; }
        public int? PromoCodeMasterId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}