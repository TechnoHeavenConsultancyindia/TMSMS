using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.VisaService.VisaServices
{
    public partial interface IVisaDiscountCategoryRepository : IRepository<VisaDiscountCategory, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            string? description = null,
            CancellationToken cancellationToken = default);
        Task<List<VisaDiscountCategory>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    string? description = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? description = null,
            CancellationToken cancellationToken = default);
    }
}