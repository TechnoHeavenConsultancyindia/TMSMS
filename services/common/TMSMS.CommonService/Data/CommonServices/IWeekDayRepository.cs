using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IWeekDayRepository : IRepository<WeekDay, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            string? dayAbbreviation = null,
            bool? isWeekend = null,
            int? displayOrderMin = null,
            int? displayOrderMax = null,
            CancellationToken cancellationToken = default);
        Task<List<WeekDay>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    string? dayAbbreviation = null,
                    bool? isWeekend = null,
                    int? displayOrderMin = null,
                    int? displayOrderMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? dayAbbreviation = null,
            bool? isWeekend = null,
            int? displayOrderMin = null,
            int? displayOrderMax = null,
            CancellationToken cancellationToken = default);
    }
}