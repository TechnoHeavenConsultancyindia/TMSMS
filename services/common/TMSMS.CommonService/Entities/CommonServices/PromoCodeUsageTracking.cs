using TMSMS.CommonService.CommonServices;
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
    public abstract class PromoCodeUsageTrackingBase : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual int UserID { get; set; }

        public virtual int BookingID { get; set; }

        public virtual DateTime UsageDate { get; set; }
        public int? PromoCodeMasterId { get; set; }

        protected PromoCodeUsageTrackingBase()
        {

        }

        public PromoCodeUsageTrackingBase(int? promoCodeMasterId, int userID, int bookingID, DateTime usageDate)
        {

            UserID = userID;
            BookingID = bookingID;
            UsageDate = usageDate;
            PromoCodeMasterId = promoCodeMasterId;
        }

    }
}