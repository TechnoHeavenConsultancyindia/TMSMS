using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.TransferService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class TransferServiceDbContextFactory : IDesignTimeDbContextFactory<TransferServiceDbContext>
{
    public TransferServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TransferServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__TransferService_Migrations");
        });

        return new TransferServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(TransferServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{TransferServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
