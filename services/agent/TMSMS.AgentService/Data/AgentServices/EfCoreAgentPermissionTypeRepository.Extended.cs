using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.AgentService.Data;

namespace TMSMS.AgentService.AgentServices
{
    public class EfCoreAgentPermissionTypeRepository : EfCoreAgentPermissionTypeRepositoryBase, IAgentPermissionTypeRepository
    {
        public EfCoreAgentPermissionTypeRepository(IDbContextProvider<AgentServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}