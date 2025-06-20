using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LanguageManagement.External;

namespace TMSMS.LanguageService.Data;

[ConnectionStringName(DatabaseName)]
[ReplaceDbContext(typeof(ILanguageManagementDbContext))]
public class LanguageServiceDbContext :
    AbpDbContext<LanguageServiceDbContext>,
    ILanguageManagementDbContext,
    IHasEventInbox,
    IHasEventOutbox
{
    public const string DbTablePrefix = "";
    public const string DbSchema = null;
    
    public const string DatabaseName = "LanguageService";
    
    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public DbSet<Language> Languages { get; }
    public DbSet<LanguageText> LanguageTexts { get; }
    public DbSet<LocalizationResourceRecord> LocalizationResources { get; }
    public DbSet<LocalizationTextRecord> LocalizationTexts { get; }

    public LanguageServiceDbContext(DbContextOptions<LanguageServiceDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();
        builder.ConfigureLanguageManagement();
    }
}