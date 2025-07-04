using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IPromoCodeUsageTrackingRepository : IRepository<PromoCodeUsageTracking, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null,
            CancellationToken cancellationToken = default);
        Task<PromoCodeUsageTrackingWithNavigationProperties> GetWithNavigationPropertiesAsync(
            int id,
            CancellationToken cancellationToken = default
        );

        Task<List<PromoCodeUsageTrackingWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<PromoCodeUsageTracking>> GetListAsync(
                    string? filterText = null,
                    int? userIDMin = null,
                    int? userIDMax = null,
                    int? bookingIDMin = null,
                    int? bookingIDMax = null,
                    DateTime? usageDateMin = null,
                    DateTime? usageDateMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? userIDMin = null,
            int? userIDMax = null,
            int? bookingIDMin = null,
            int? bookingIDMax = null,
            DateTime? usageDateMin = null,
            DateTime? usageDateMax = null,
            int? promoCodeMasterId = null,
            CancellationToken cancellationToken = default);
    }
}