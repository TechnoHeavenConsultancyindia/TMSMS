using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.CommonService.Data;

namespace TMSMS.CommonService.CommonServices
{
    public abstract class EfCoreCityRepositoryBase : EfCoreRepository<CommonServiceDbContext, City, int>
    {
        public EfCoreCityRepositoryBase(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? locationId = null,
            string? name = null,
            string? fullName = null,
            string? latitude = null,
            string? longitude = null,
            string? countryCode = null,
            string? countrySubdivisionCode = null,
            string? iataAirportCode = null,
            string? iataAirportMetroCode = null,
            string? polygonType = null,
            string? categories = null,
            string? tags = null,
            int? statusFlagMin = null,
            int? statusFlagMax = null,
            string? descriptor = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, locationId, name, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, statusFlagMin, statusFlagMax, descriptor);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<City>> GetListAsync(
            string? filterText = null,
            string? locationId = null,
            string? name = null,
            string? fullName = null,
            string? latitude = null,
            string? longitude = null,
            string? countryCode = null,
            string? countrySubdivisionCode = null,
            string? iataAirportCode = null,
            string? iataAirportMetroCode = null,
            string? polygonType = null,
            string? categories = null,
            string? tags = null,
            int? statusFlagMin = null,
            int? statusFlagMax = null,
            string? descriptor = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, locationId, name, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, statusFlagMin, statusFlagMax, descriptor);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CityConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? locationId = null,
            string? name = null,
            string? fullName = null,
            string? latitude = null,
            string? longitude = null,
            string? countryCode = null,
            string? countrySubdivisionCode = null,
            string? iataAirportCode = null,
            string? iataAirportMetroCode = null,
            string? polygonType = null,
            string? categories = null,
            string? tags = null,
            int? statusFlagMin = null,
            int? statusFlagMax = null,
            string? descriptor = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, locationId, name, fullName, latitude, longitude, countryCode, countrySubdivisionCode, iataAirportCode, iataAirportMetroCode, polygonType, categories, tags, statusFlagMin, statusFlagMax, descriptor);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<City> ApplyFilter(
            IQueryable<City> query,
            string? filterText = null,
            string? locationId = null,
            string? name = null,
            string? fullName = null,
            string? latitude = null,
            string? longitude = null,
            string? countryCode = null,
            string? countrySubdivisionCode = null,
            string? iataAirportCode = null,
            string? iataAirportMetroCode = null,
            string? polygonType = null,
            string? categories = null,
            string? tags = null,
            int? statusFlagMin = null,
            int? statusFlagMax = null,
            string? descriptor = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.LocationId!.Contains(filterText!) || e.Name!.Contains(filterText!) || e.FullName!.Contains(filterText!) || e.Latitude!.Contains(filterText!) || e.Longitude!.Contains(filterText!) || e.CountryCode!.Contains(filterText!) || e.CountrySubdivisionCode!.Contains(filterText!) || e.IataAirportCode!.Contains(filterText!) || e.IataAirportMetroCode!.Contains(filterText!) || e.PolygonType!.Contains(filterText!) || e.Categories!.Contains(filterText!) || e.Tags!.Contains(filterText!) || e.Descriptor!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(locationId), e => e.LocationId.Contains(locationId))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(fullName), e => e.FullName.Contains(fullName))
                    .WhereIf(!string.IsNullOrWhiteSpace(latitude), e => e.Latitude.Contains(latitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(longitude), e => e.Longitude.Contains(longitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(countryCode), e => e.CountryCode.Contains(countryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(countrySubdivisionCode), e => e.CountrySubdivisionCode.Contains(countrySubdivisionCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(iataAirportCode), e => e.IataAirportCode.Contains(iataAirportCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(iataAirportMetroCode), e => e.IataAirportMetroCode.Contains(iataAirportMetroCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(polygonType), e => e.PolygonType.Contains(polygonType))
                    .WhereIf(!string.IsNullOrWhiteSpace(categories), e => e.Categories.Contains(categories))
                    .WhereIf(!string.IsNullOrWhiteSpace(tags), e => e.Tags.Contains(tags))
                    .WhereIf(statusFlagMin.HasValue, e => e.StatusFlag >= statusFlagMin!.Value)
                    .WhereIf(statusFlagMax.HasValue, e => e.StatusFlag <= statusFlagMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(descriptor), e => e.Descriptor.Contains(descriptor));
        }
    }
}