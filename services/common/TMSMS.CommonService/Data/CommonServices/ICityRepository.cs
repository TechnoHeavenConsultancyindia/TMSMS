using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface ICityRepository : IRepository<City, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? locationId = null,
            string? name = null,
            string? fullName = null,
            string? descriptor = null,
            string? iataAirportCode = null,
            string? iataAirportMetroCode = null,
            string? countrySubdivisionCode = null,
            string? latitude = null,
            string? longitude = null,
            string? polygonType = null,
            string? countryCode = null,
            string? categories = null,
            string? tags = null,
            int? statusFlagMin = null,
            int? statusFlagMax = null,
            CancellationToken cancellationToken = default);
        Task<List<City>> GetListAsync(
                    string? filterText = null,
                    string? locationId = null,
                    string? name = null,
                    string? fullName = null,
                    string? descriptor = null,
                    string? iataAirportCode = null,
                    string? iataAirportMetroCode = null,
                    string? countrySubdivisionCode = null,
                    string? latitude = null,
                    string? longitude = null,
                    string? polygonType = null,
                    string? countryCode = null,
                    string? categories = null,
                    string? tags = null,
                    int? statusFlagMin = null,
                    int? statusFlagMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? locationId = null,
            string? name = null,
            string? fullName = null,
            string? descriptor = null,
            string? iataAirportCode = null,
            string? iataAirportMetroCode = null,
            string? countrySubdivisionCode = null,
            string? latitude = null,
            string? longitude = null,
            string? polygonType = null,
            string? countryCode = null,
            string? categories = null,
            string? tags = null,
            int? statusFlagMin = null,
            int? statusFlagMax = null,
            CancellationToken cancellationToken = default);
    }
}