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
    public DbSet<VisaDiscountCategory> VisaDiscountCategories { get; set; } = null!;
    public DbSet<VisaType> VisaTypes { get; set; } = null!;
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
        builder.Entity<VisaType>(b =>
                {
                    b.ToTable(DbTablePrefix + "VisaTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(VisaType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(VisaType.Name)).IsRequired().HasMaxLength(VisaTypeConsts.NameMaxLength);
                    b.Property(x => x.SubCategory).HasColumnName(nameof(VisaType.SubCategory)).HasMaxLength(VisaTypeConsts.SubCategoryMaxLength);
                    b.Property(x => x.VisaPurpose).HasColumnName(nameof(VisaType.VisaPurpose));
                    b.Property(x => x.Description).HasColumnName(nameof(VisaType.Description));
                });
        builder.Entity<VisaDiscountCategory>(b =>
                {
                    b.ToTable(DbTablePrefix + "VisaDiscountCategories", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(VisaDiscountCategory.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(VisaDiscountCategory.Name)).IsRequired().HasMaxLength(VisaDiscountCategoryConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(VisaDiscountCategory.Description)).HasMaxLength(VisaDiscountCategoryConsts.DescriptionMaxLength);
                });
    }
}