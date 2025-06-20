using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.RestaurantService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class RestaurantServiceDbContextFactory : IDesignTimeDbContextFactory<RestaurantServiceDbContext>
{
    public RestaurantServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RestaurantServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__RestaurantService_Migrations");
        });

        return new RestaurantServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(RestaurantServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{RestaurantServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
