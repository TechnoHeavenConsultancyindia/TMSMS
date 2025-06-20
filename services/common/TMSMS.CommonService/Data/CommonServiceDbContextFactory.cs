using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.CommonService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class CommonServiceDbContextFactory : IDesignTimeDbContextFactory<CommonServiceDbContext>
{
    public CommonServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CommonServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__CommonService_Migrations");
        });

        return new CommonServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(CommonServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{CommonServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
