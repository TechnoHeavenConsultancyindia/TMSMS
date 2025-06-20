using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.TourService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class TourServiceDbContextFactory : IDesignTimeDbContextFactory<TourServiceDbContext>
{
    public TourServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TourServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__TourService_Migrations");
        });

        return new TourServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(TourServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{TourServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
