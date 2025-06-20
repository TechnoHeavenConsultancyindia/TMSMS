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
    public abstract class EfCoreCountryRepositoryBase : EfCoreRepository<CommonServiceDbContext, Country, int>
    {
        public EfCoreCountryRepositoryBase(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
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
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, locationId, name, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, categories, tags, statusFlagMin, statusFlagMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Country>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, locationId, name, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, categories, tags, statusFlagMin, statusFlagMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CountryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, locationId, name, fullName, descriptor, iataAirportCode, iataAirportMetroCode, countrySubdivisionCode, latitude, longitude, polygonType, countryCode, categories, tags, statusFlagMin, statusFlagMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Country> ApplyFilter(
            IQueryable<Country> query,
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
            int? statusFlagMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.LocationId!.Contains(filterText!) || e.Name!.Contains(filterText!) || e.FullName!.Contains(filterText!) || e.Descriptor!.Contains(filterText!) || e.IataAirportCode!.Contains(filterText!) || e.IataAirportMetroCode!.Contains(filterText!) || e.CountrySubdivisionCode!.Contains(filterText!) || e.Latitude!.Contains(filterText!) || e.Longitude!.Contains(filterText!) || e.PolygonType!.Contains(filterText!) || e.CountryCode!.Contains(filterText!) || e.Categories!.Contains(filterText!) || e.Tags!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(locationId), e => e.LocationId.Contains(locationId))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(fullName), e => e.FullName.Contains(fullName))
                    .WhereIf(!string.IsNullOrWhiteSpace(descriptor), e => e.Descriptor.Contains(descriptor))
                    .WhereIf(!string.IsNullOrWhiteSpace(iataAirportCode), e => e.IataAirportCode.Contains(iataAirportCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(iataAirportMetroCode), e => e.IataAirportMetroCode.Contains(iataAirportMetroCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(countrySubdivisionCode), e => e.CountrySubdivisionCode.Contains(countrySubdivisionCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(latitude), e => e.Latitude.Contains(latitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(longitude), e => e.Longitude.Contains(longitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(polygonType), e => e.PolygonType.Contains(polygonType))
                    .WhereIf(!string.IsNullOrWhiteSpace(countryCode), e => e.CountryCode.Contains(countryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(categories), e => e.Categories.Contains(categories))
                    .WhereIf(!string.IsNullOrWhiteSpace(tags), e => e.Tags.Contains(tags))
                    .WhereIf(statusFlagMin.HasValue, e => e.StatusFlag >= statusFlagMin!.Value)
                    .WhereIf(statusFlagMax.HasValue, e => e.StatusFlag <= statusFlagMax!.Value);
        }
    }
}