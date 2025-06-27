using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public partial interface IRestaurantDietaryTypeRepository : IRepository<RestaurantDietaryType, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            string? description = null,
            CancellationToken cancellationToken = default);
        Task<List<RestaurantDietaryType>> GetListAsync(
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