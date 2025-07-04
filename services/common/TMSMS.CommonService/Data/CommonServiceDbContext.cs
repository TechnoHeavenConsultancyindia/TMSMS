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
    public DbSet<Region> Regions { get; set; } = null!;
    public DbSet<Province> Provinces { get; set; } = null!;
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
        builder.Entity<Province>(b =>
                {
                    b.ToTable(DbTablePrefix + "Provinces", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Province.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(Province.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(Province.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(Province.FullName));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(Province.Descriptor));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(Province.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(Province.IataAirportMetroCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(Province.CountrySubdivisionCode));
                    b.Property(x => x.Latitude).HasColumnName(nameof(Province.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(Province.Longitude));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(Province.PolygonType));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(Province.CountryCode));
                    b.Property(x => x.Categories).HasColumnName(nameof(Province.Categories)).IsRequired();
                    b.Property(x => x.Tags).HasColumnName(nameof(Province.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(Province.StatusFlag));
                });

        builder.Entity<Region>(b =>
                {
                    b.ToTable(DbTablePrefix + "Regions", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Region.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(Region.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(Region.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(Region.FullName));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(Region.Descriptor));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(Region.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(Region.IataAirportMetroCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(Region.CountrySubdivisionCode));
                    b.Property(x => x.Latitude).HasColumnName(nameof(Region.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(Region.Longitude));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(Region.PolygonType));
                    b.Property(x => x.Categories).HasColumnName(nameof(Region.Categories)).IsRequired();
                    b.Property(x => x.CountryCode).HasColumnName(nameof(Region.CountryCode));
                    b.Property(x => x.Tags).HasColumnName(nameof(Region.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(Region.StatusFlag));
                });
        builder.Entity<Country>(b =>
                {
                    b.ToTable(DbTablePrefix + "Countries", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Country.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(Country.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(Country.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(Country.FullName));
                    b.Property(x => x.Latitude).HasColumnName(nameof(Country.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(Country.Longitude));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(Country.CountryCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(Country.CountrySubdivisionCode));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(Country.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(Country.IataAirportMetroCode));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(Country.PolygonType));
                    b.Property(x => x.Categories).HasColumnName(nameof(Country.Categories));
                    b.Property(x => x.Tags).HasColumnName(nameof(Country.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(Country.StatusFlag));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(Country.Descriptor));
                });
    }
}