using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TMSMS.RestaurantService.Data;

namespace TMSMS.RestaurantService.RestaurantServices
{
    public class EfCoreRestaurantCuisineRepository : EfCoreRestaurantCuisineRepositoryBase, IRestaurantCuisineRepository
    {
        public EfCoreRestaurantCuisineRepository(IDbContextProvider<RestaurantServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}