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
    public class EfCoreCountryRepository : EfCoreCountryRepositoryBase, ICountryRepository
    {
        public EfCoreCountryRepository(IDbContextProvider<CommonServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}