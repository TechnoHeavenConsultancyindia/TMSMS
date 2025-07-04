using TMSMS.CommonService.CommonServices;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace TMSMS.CommonService.Data;

[ConnectionStringName(DatabaseName)]
public class CommonServiceDbContext :
    AbpDbContext<CommonServiceDbContext>,
    IHasEventInbox,
    IHasEventOutbox
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public const string DbTablePrefix = "";
    public const string DbSchema = null;

    public const string DatabaseName = "CommonService";

    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public CommonServiceDbContext(DbContextOptions<CommonServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();
        builder.Entity<Country>(b =>
                {
                    b.ToTable(DbTablePrefix + "Countries", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Country.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(Country.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(Country.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(Country.FullName));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(Country.Descriptor));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(Country.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(Country.IataAirportMetroCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(Country.CountrySubdivisionCode));
                    b.Property(x => x.Latitude).HasColumnName(nameof(Country.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(Country.Longitude));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(Country.PolygonType));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(Country.CountryCode));
                    b.Property(x => x.Categories).HasColumnName(nameof(Country.Categories)).IsRequired();
                    b.Property(x => x.Tags).HasColumnName(nameof(Country.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(Country.StatusFlag));
                });
        builder.Entity<City>(b =>
                {
                    b.ToTable(DbTablePrefix + "Cities", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(City.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(City.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(City.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(City.FullName));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(City.Descriptor));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(City.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(City.IataAirportMetroCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(City.CountrySubdivisionCode));
                    b.Property(x => x.Latitude).HasColumnName(nameof(City.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(City.Longitude));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(City.PolygonType));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(City.CountryCode));
                    b.Property(x => x.Categories).HasColumnName(nameof(City.Categories));
                    b.Property(x => x.Tags).HasColumnName(nameof(City.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(City.StatusFlag));
                });
    }
}