using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.TransferService.Data;

namespace TMSMS.TransferService.TransferServices
{
    public class EfCoreTransferTypeRepository : EfCoreTransferTypeRepositoryBase, ITransferTypeRepository
    {
        public EfCoreTransferTypeRepository(IDbContextProvider<TransferServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}