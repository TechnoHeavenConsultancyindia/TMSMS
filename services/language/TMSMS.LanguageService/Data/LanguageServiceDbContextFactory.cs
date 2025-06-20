using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.LanguageService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class LanguageServiceDbContextFactory : IDesignTimeDbContextFactory<LanguageServiceDbContext>
{
    public LanguageServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<LanguageServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__LanguageService_Migrations");
        });

        return new LanguageServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(LanguageServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{LanguageServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
