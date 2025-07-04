using TMSMS.CommonService.CommonServices;
using TMSMS.CommonService.CommonServices;
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
    public abstract class EfCoreSupplierMasterRepositoryBase : EfCoreRepository<CommonServiceDbContext, SupplierMaster, int>
    {
        public EfCoreSupplierMasterRepositoryBase(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            string? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            int? supplierStatusMin = null,
            int? supplierStatusMax = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();

            query = ApplyFilter(query, filterText, name, type, contactName, contactEmail, dialCode, contactPhone, supplierStatusMin, supplierStatusMax, preffered, countryId, supplierServiceTypeId);

            var ids = query.Select(x => x.SupplierMaster.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<SupplierMasterWithNavigationProperties> GetWithNavigationPropertiesAsync(int id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(supplierMaster => new SupplierMasterWithNavigationProperties
                {
                    SupplierMaster = supplierMaster,
                    Country = dbContext.Set<Country>().FirstOrDefault(c => c.Id == supplierMaster.CountryId),
                    SupplierServiceType = dbContext.Set<SupplierServiceType>().FirstOrDefault(c => c.Id == supplierMaster.SupplierServiceTypeId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<SupplierMasterWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? name = null,
            string? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            int? supplierStatusMin = null,
            int? supplierStatusMax = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, type, contactName, contactEmail, dialCode, contactPhone, supplierStatusMin, supplierStatusMax, preffered, countryId, supplierServiceTypeId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? SupplierMasterConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<SupplierMasterWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from supplierMaster in (await GetDbSetAsync())
                   join country in (await GetDbContextAsync()).Set<Country>() on supplierMaster.CountryId equals country.Id into countries
                   from country in countries.DefaultIfEmpty()
                   join supplierServiceType in (await GetDbContextAsync()).Set<SupplierServiceType>() on supplierMaster.SupplierServiceTypeId equals supplierServiceType.Id into supplierServiceTypes
                   from supplierServiceType in supplierServiceTypes.DefaultIfEmpty()
                   select new SupplierMasterWithNavigationProperties
                   {
                       SupplierMaster = supplierMaster,
                       Country = country,
                       SupplierServiceType = supplierServiceType
                   };
        }

        protected virtual IQueryable<SupplierMasterWithNavigationProperties> ApplyFilter(
            IQueryable<SupplierMasterWithNavigationProperties> query,
            string? filterText,
            string? name = null,
            string? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            int? supplierStatusMin = null,
            int? supplierStatusMax = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.SupplierMaster.Name!.Contains(filterText!) || e.SupplierMaster.Type!.Contains(filterText!) || e.SupplierMaster.ContactName!.Contains(filterText!) || e.SupplierMaster.ContactEmail!.Contains(filterText!) || e.SupplierMaster.DialCode!.Contains(filterText!) || e.SupplierMaster.ContactPhone!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.SupplierMaster.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.SupplierMaster.Type.Contains(type))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName), e => e.SupplierMaster.ContactName.Contains(contactName))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactEmail), e => e.SupplierMaster.ContactEmail.Contains(contactEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(dialCode), e => e.SupplierMaster.DialCode.Contains(dialCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPhone), e => e.SupplierMaster.ContactPhone.Contains(contactPhone))
                    .WhereIf(supplierStatusMin.HasValue, e => e.SupplierMaster.SupplierStatus >= supplierStatusMin!.Value)
                    .WhereIf(supplierStatusMax.HasValue, e => e.SupplierMaster.SupplierStatus <= supplierStatusMax!.Value)
                    .WhereIf(preffered.HasValue, e => e.SupplierMaster.Preffered == preffered)
                    .WhereIf(countryId != null, e => e.Country != null && e.Country.Id == countryId)
                    .WhereIf(supplierServiceTypeId != null, e => e.SupplierServiceType != null && e.SupplierServiceType.Id == supplierServiceTypeId);
        }

        public virtual async Task<List<SupplierMaster>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            int? supplierStatusMin = null,
            int? supplierStatusMax = null,
            bool? preffered = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, type, contactName, contactEmail, dialCode, contactPhone, supplierStatusMin, supplierStatusMax, preffered);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? SupplierMasterConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            int? supplierStatusMin = null,
            int? supplierStatusMax = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, name, type, contactName, contactEmail, dialCode, contactPhone, supplierStatusMin, supplierStatusMax, preffered, countryId, supplierServiceTypeId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<SupplierMaster> ApplyFilter(
            IQueryable<SupplierMaster> query,
            string? filterText = null,
            string? name = null,
            string? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            int? supplierStatusMin = null,
            int? supplierStatusMax = null,
            bool? preffered = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.Type!.Contains(filterText!) || e.ContactName!.Contains(filterText!) || e.ContactEmail!.Contains(filterText!) || e.DialCode!.Contains(filterText!) || e.ContactPhone!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.Type.Contains(type))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactName), e => e.ContactName.Contains(contactName))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactEmail), e => e.ContactEmail.Contains(contactEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(dialCode), e => e.DialCode.Contains(dialCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(contactPhone), e => e.ContactPhone.Contains(contactPhone))
                    .WhereIf(supplierStatusMin.HasValue, e => e.SupplierStatus >= supplierStatusMin!.Value)
                    .WhereIf(supplierStatusMax.HasValue, e => e.SupplierStatus <= supplierStatusMax!.Value)
                    .WhereIf(preffered.HasValue, e => e.Preffered == preffered);
        }
    }
}