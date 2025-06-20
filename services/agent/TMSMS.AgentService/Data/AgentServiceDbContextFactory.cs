using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMSMS.AgentService.Data;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class AgentServiceDbContextFactory : IDesignTimeDbContextFactory<AgentServiceDbContext>
{
    public AgentServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AgentServiceDbContext>()
        .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
        {
            b.MigrationsHistoryTable("__AgentService_Migrations");
        });

        return new AgentServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(AgentServiceDbContext.DatabaseName)
               ?? throw new ApplicationException($"Could not find a connection string named '{AgentServiceDbContext.DatabaseName}'.");
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
