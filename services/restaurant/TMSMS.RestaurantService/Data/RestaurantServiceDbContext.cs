using TMSMS.RestaurantService.RestaurantServices;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace TMSMS.RestaurantService.Data;

[ConnectionStringName(DatabaseName)]
public class RestaurantServiceDbContext :
    AbpDbContext<RestaurantServiceDbContext>,
    IHasEventInbox,
    IHasEventOutbox
{
    public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; } = null!;
    public DbSet<RestaurantDietaryType> RestaurantDietaryTypes { get; set; } = null!;
    public DbSet<RestaurantTag> RestaurantTags { get; set; } = null!;
    public DbSet<RestaurantType> RestaurantTypes { get; set; } = null!;
    public const string DbTablePrefix = "";
    public const string DbSchema = null;

    public const string DatabaseName = "RestaurantService";

    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public RestaurantServiceDbContext(DbContextOptions<RestaurantServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();

        builder.Entity<RestaurantType>(b =>
                {
                    b.ToTable(DbTablePrefix + "RestaurantTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(RestaurantType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(RestaurantType.Name)).IsRequired().HasMaxLength(RestaurantTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(RestaurantType.Description)).HasMaxLength(RestaurantTypeConsts.DescriptionMaxLength);
                });
        builder.Entity<RestaurantTag>(b =>
                {
                    b.ToTable(DbTablePrefix + "RestaurantTags", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(RestaurantTag.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(RestaurantTag.Name)).IsRequired().HasMaxLength(RestaurantTagConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(RestaurantTag.Description)).HasMaxLength(RestaurantTagConsts.DescriptionMaxLength);
                });
        builder.Entity<RestaurantDietaryType>(b =>
                {
                    b.ToTable(DbTablePrefix + "RestaurantDietaryTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(RestaurantDietaryType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(RestaurantDietaryType.Name)).IsRequired().HasMaxLength(RestaurantDietaryTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(RestaurantDietaryType.Description)).HasMaxLength(RestaurantDietaryTypeConsts.DescriptionMaxLength);
                });
        builder.Entity<RestaurantCuisine>(b =>
                {
                    b.ToTable(DbTablePrefix + "RestaurantCuisines", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(RestaurantCuisine.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(RestaurantCuisine.Name)).IsRequired().HasMaxLength(RestaurantCuisineConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(RestaurantCuisine.Description)).HasMaxLength(RestaurantCuisineConsts.DescriptionMaxLength);
                });
    }
}