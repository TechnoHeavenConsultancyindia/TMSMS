using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;
using Volo.Abp.Gdpr;

namespace TMSMS.GdprService.Data;

[ConnectionStringName(DatabaseName)]
[ReplaceDbContext(typeof(IGdprDbContext))]
public class GdprServiceDbContext :
    AbpDbContext<GdprServiceDbContext>,
    IGdprDbContext,
    IHasEventInbox,
    IHasEventOutbox
{
    public const string DbTablePrefix = "";
    public const string DbSchema = null;
    
    public const string DatabaseName = "GdprService";
    
    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public DbSet<GdprRequest> Requests { get; set; }

    public GdprServiceDbContext(DbContextOptions<GdprServiceDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();
        builder.ConfigureGdpr();
    }
}