using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.GdprService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class GdprServiceDbContextFactory : IDesignTimeDbContextFactory<GdprServiceDbContext>
{
    public GdprServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<GdprServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__GdprService_Migrations");
        });

        return new GdprServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(GdprServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{GdprServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
