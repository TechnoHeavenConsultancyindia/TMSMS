using TMSMS.VisaService.VisaServices;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace TMSMS.VisaService.Data;

[ConnectionStringName(DatabaseName)]
public class VisaServiceDbContext :
    AbpDbContext<VisaServiceDbContext>,
    IHasEventInbox,
    IHasEventOutbox
{
    public DbSet<VisaTermCategory> VisaTermCategories { get; set; } = null!;
    public const string DbTablePrefix = "";
    public const string DbSchema = null;

    public const string DatabaseName = "VisaService";

    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public VisaServiceDbContext(DbContextOptions<VisaServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();

        builder.Entity<VisaTermCategory>(b =>
                {
                    b.ToTable(DbTablePrefix + "VisaTermCategories", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(VisaTermCategory.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(VisaTermCategory.Name)).HasMaxLength(VisaTermCategoryConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(VisaTermCategory.Description)).HasMaxLength(VisaTermCategoryConsts.DescriptionMaxLength);
                });
    }
}