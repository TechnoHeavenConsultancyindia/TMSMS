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
    public abstract class PromoCodeUsageTrackingManagerBase : DomainService
    {
        protected IPromoCodeUsageTrackingRepository _promoCodeUsageTrackingRepository;

        public PromoCodeUsageTrackingManagerBase(IPromoCodeUsageTrackingRepository promoCodeUsageTrackingRepository)
        {
            _promoCodeUsageTrackingRepository = promoCodeUsageTrackingRepository;
        }

        public virtual async Task<PromoCodeUsageTracking> CreateAsync(
        int? promoCodeMasterId, int userID, int bookingID, DateTime usageDate)
        {
            Check.NotNull(usageDate, nameof(usageDate));

            var promoCodeUsageTracking = new PromoCodeUsageTracking(

             promoCodeMasterId, userID, bookingID, usageDate
             );

            return await _promoCodeUsageTrackingRepository.InsertAsync(promoCodeUsageTracking);
        }

        public virtual async Task<PromoCodeUsageTracking> UpdateAsync(
            int id,
            int? promoCodeMasterId, int userID, int bookingID, DateTime usageDate, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(usageDate, nameof(usageDate));

            var promoCodeUsageTracking = await _promoCodeUsageTrackingRepository.GetAsync(id);

            promoCodeUsageTracking.PromoCodeMasterId = promoCodeMasterId;
            promoCodeUsageTracking.UserID = userID;
            promoCodeUsageTracking.BookingID = bookingID;
            promoCodeUsageTracking.UsageDate = usageDate;

            promoCodeUsageTracking.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _promoCodeUsageTrackingRepository.UpdateAsync(promoCodeUsageTracking);
        }

    }
}