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
    public class EfCoreVisaTypeRepository : EfCoreVisaTypeRepositoryBase, IVisaTypeRepository
    {
        public EfCoreVisaTypeRepository(IDbContextProvider<VisaServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}