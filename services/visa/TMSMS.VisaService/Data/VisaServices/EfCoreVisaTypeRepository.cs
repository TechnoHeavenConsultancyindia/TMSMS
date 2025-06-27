using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.VisaService.Data;

namespace TMSMS.VisaService.VisaServices
{
    public abstract class EfCoreVisaTypeRepositoryBase : EfCoreRepository<VisaServiceDbContext, VisaType, int>
    {
        public EfCoreVisaTypeRepositoryBase(IDbContextProvider<VisaServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            string? subCategory = null,
            string? visaPurpose = null,
            string? description = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, name, subCategory, visaPurpose, description);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<VisaType>> GetListAsync(
            string? filterText = null,
            string? name = null,
            string? subCategory = null,
            string? visaPurpose = null,
            string? description = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, subCategory, visaPurpose, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? VisaTypeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            string? subCategory = null,
            string? visaPurpose = null,
            string? description = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, subCategory, visaPurpose, description);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<VisaType> ApplyFilter(
            IQueryable<VisaType> query,
            string? filterText = null,
            string? name = null,
            string? subCategory = null,
            string? visaPurpose = null,
            string? description = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.SubCategory!.Contains(filterText!) || e.VisaPurpose!.Contains(filterText!) || e.Description!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(subCategory), e => e.SubCategory.Contains(subCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(visaPurpose), e => e.VisaPurpose.Contains(visaPurpose))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description));
        }
    }
}