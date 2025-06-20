using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.VisaService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class VisaServiceDbContextFactory : IDesignTimeDbContextFactory<VisaServiceDbContext>
{
    public VisaServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<VisaServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__VisaService_Migrations");
        });

        return new VisaServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(VisaServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{VisaServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
