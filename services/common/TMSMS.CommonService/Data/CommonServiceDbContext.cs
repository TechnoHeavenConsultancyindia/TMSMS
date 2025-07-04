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
    public DbSet<SupplierServiceType> SupplierServiceTypes { get; set; } = null!;
    public DbSet<PromoCodeUsageTracking> PromoCodeUsageTrackings { get; set; } = null!;
    public DbSet<PromoCodeMaster> PromoCodeMasters { get; set; } = null!;
    public DbSet<WeekDay> WeekDays { get; set; } = null!;
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
        builder.Entity<City>(b =>
                {
                    b.ToTable(DbTablePrefix + "Cities", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(City.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(City.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(City.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(City.FullName));
                    b.Property(x => x.Latitude).HasColumnName(nameof(City.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(City.Longitude));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(City.CountryCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(City.CountrySubdivisionCode));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(City.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(City.IataAirportMetroCode));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(City.PolygonType));
                    b.Property(x => x.Categories).HasColumnName(nameof(City.Categories));
                    b.Property(x => x.Tags).HasColumnName(nameof(City.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(City.StatusFlag));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(City.Descriptor));
                });
        builder.Entity<Province>(b =>
                {
                    b.ToTable(DbTablePrefix + "Provinces", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Province.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(Province.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(Province.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(Province.FullName));
                    b.Property(x => x.Latitude).HasColumnName(nameof(Province.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(Province.Longitude));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(Province.CountryCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(Province.CountrySubdivisionCode));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(Province.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(Province.IataAirportMetroCode));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(Province.PolygonType));
                    b.Property(x => x.Categories).HasColumnName(nameof(Province.Categories));
                    b.Property(x => x.Tags).HasColumnName(nameof(Province.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(Province.StatusFlag));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(Province.Descriptor));
                });
        builder.Entity<Region>(b =>
                {
                    b.ToTable(DbTablePrefix + "Regions", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(Region.TenantId));
                    b.Property(x => x.LocationId).HasColumnName(nameof(Region.LocationId));
                    b.Property(x => x.Name).HasColumnName(nameof(Region.Name)).IsRequired();
                    b.Property(x => x.FullName).HasColumnName(nameof(Region.FullName));
                    b.Property(x => x.Latitude).HasColumnName(nameof(Region.Latitude));
                    b.Property(x => x.Longitude).HasColumnName(nameof(Region.Longitude));
                    b.Property(x => x.CountryCode).HasColumnName(nameof(Region.CountryCode));
                    b.Property(x => x.CountrySubdivisionCode).HasColumnName(nameof(Region.CountrySubdivisionCode));
                    b.Property(x => x.IataAirportCode).HasColumnName(nameof(Region.IataAirportCode));
                    b.Property(x => x.IataAirportMetroCode).HasColumnName(nameof(Region.IataAirportMetroCode));
                    b.Property(x => x.PolygonType).HasColumnName(nameof(Region.PolygonType));
                    b.Property(x => x.Categories).HasColumnName(nameof(Region.Categories));
                    b.Property(x => x.Tags).HasColumnName(nameof(Region.Tags));
                    b.Property(x => x.StatusFlag).HasColumnName(nameof(Region.StatusFlag));
                    b.Property(x => x.Descriptor).HasColumnName(nameof(Region.Descriptor));
                });
        builder.Entity<WeekDay>(b =>
                {
                    b.ToTable(DbTablePrefix + "WeekDays", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(WeekDay.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(WeekDay.Name)).IsRequired().HasMaxLength(WeekDayConsts.NameMaxLength);
                    b.Property(x => x.DayAbbreviation).HasColumnName(nameof(WeekDay.DayAbbreviation)).IsRequired().HasMaxLength(WeekDayConsts.DayAbbreviationMaxLength);
                    b.Property(x => x.IsWeekend).HasColumnName(nameof(WeekDay.IsWeekend));
                    b.Property(x => x.DisplayOrder).HasColumnName(nameof(WeekDay.DisplayOrder));
                });
        builder.Entity<PromoCodeMaster>(b =>
                {
                    b.ToTable(DbTablePrefix + "PromoCodeMasters", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(PromoCodeMaster.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(PromoCodeMaster.Name)).IsRequired().HasMaxLength(PromoCodeMasterConsts.NameMaxLength);
                    b.Property(x => x.PromoCode).HasColumnName(nameof(PromoCodeMaster.PromoCode)).HasMaxLength(PromoCodeMasterConsts.PromoCodeMaxLength);
                    b.Property(x => x.ServiceType).HasColumnName(nameof(PromoCodeMaster.ServiceType)).HasMaxLength(PromoCodeMasterConsts.ServiceTypeMaxLength);
                    b.Property(x => x.DiscountType).HasColumnName(nameof(PromoCodeMaster.DiscountType)).HasMaxLength(PromoCodeMasterConsts.DiscountTypeMaxLength);
                    b.Property(x => x.DiscountValue).HasColumnName(nameof(PromoCodeMaster.DiscountValue));
                    b.Property(x => x.DateEffectiveFrom).HasColumnName(nameof(PromoCodeMaster.DateEffectiveFrom));
                    b.Property(x => x.DateEffectiveTo).HasColumnName(nameof(PromoCodeMaster.DateEffectiveTo));
                    b.Property(x => x.MaxUsageLimit).HasColumnName(nameof(PromoCodeMaster.MaxUsageLimit));
                    b.Property(x => x.MaxUsagePerUser).HasColumnName(nameof(PromoCodeMaster.MaxUsagePerUser));
                    b.Property(x => x.CustomerType).HasColumnName(nameof(PromoCodeMaster.CustomerType)).HasMaxLength(PromoCodeMasterConsts.CustomerTypeMaxLength);
                    b.Property(x => x.MinBookingAmount).HasColumnName(nameof(PromoCodeMaster.MinBookingAmount));
                    b.Property(x => x.PaymentMethod).HasColumnName(nameof(PromoCodeMaster.PaymentMethod)).HasMaxLength(PromoCodeMasterConsts.PaymentMethodMaxLength);
                    b.Property(x => x.UserGroup).HasColumnName(nameof(PromoCodeMaster.UserGroup)).HasMaxLength(PromoCodeMasterConsts.UserGroupMaxLength);
                    b.Property(x => x.MinNoOfNights).HasColumnName(nameof(PromoCodeMaster.MinNoOfNights));
                    b.Property(x => x.MinNoOfPax).HasColumnName(nameof(PromoCodeMaster.MinNoOfPax));
                    b.Property(x => x.EarlyBirdDays).HasColumnName(nameof(PromoCodeMaster.EarlyBirdDays));
                    b.Property(x => x.ValidTimeFrom).HasColumnName(nameof(PromoCodeMaster.ValidTimeFrom));
                    b.Property(x => x.ValidTimeTo).HasColumnName(nameof(PromoCodeMaster.ValidTimeTo));
                    b.Property(x => x.Stackable).HasColumnName(nameof(PromoCodeMaster.Stackable));
                    b.HasMany(x => x.Countries).WithOne().HasForeignKey(x => x.PromoCodeMasterId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                    b.HasMany(x => x.Cities).WithOne().HasForeignKey(x => x.PromoCodeMasterId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                });

        builder.Entity<PromoCodeMasterCountry>(b =>
    {
        b.ToTable(DbTablePrefix + "PromoCodeMasterCountry", DbSchema);
        b.ConfigureByConvention();

        b.HasKey(
            x => new { x.PromoCodeMasterId, x.CountryId }
        );

        b.HasOne<PromoCodeMaster>().WithMany(x => x.Countries).HasForeignKey(x => x.PromoCodeMasterId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        b.HasOne<Country>().WithMany().HasForeignKey(x => x.CountryId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(
                x => new { x.PromoCodeMasterId, x.CountryId }
        );
    });
        builder.Entity<PromoCodeMasterCity>(b =>
    {
        b.ToTable(DbTablePrefix + "PromoCodeMasterCity", DbSchema);
        b.ConfigureByConvention();

        b.HasKey(
            x => new { x.PromoCodeMasterId, x.CityId }
        );

        b.HasOne<PromoCodeMaster>().WithMany(x => x.Cities).HasForeignKey(x => x.PromoCodeMasterId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        b.HasOne<City>().WithMany().HasForeignKey(x => x.CityId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(
                x => new { x.PromoCodeMasterId, x.CityId }
        );
    });
        builder.Entity<PromoCodeUsageTracking>(b =>
                {
                    b.ToTable(DbTablePrefix + "PromoCodeUsageTrackings", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(PromoCodeUsageTracking.TenantId));
                    b.Property(x => x.UserID).HasColumnName(nameof(PromoCodeUsageTracking.UserID));
                    b.Property(x => x.BookingID).HasColumnName(nameof(PromoCodeUsageTracking.BookingID));
                    b.Property(x => x.UsageDate).HasColumnName(nameof(PromoCodeUsageTracking.UsageDate));
                    b.HasOne<PromoCodeMaster>().WithMany().HasForeignKey(x => x.PromoCodeMasterId).OnDelete(DeleteBehavior.SetNull);
                });
        builder.Entity<SupplierServiceType>(b =>
                {
                    b.ToTable(DbTablePrefix + "SupplierServiceTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(SupplierServiceType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(SupplierServiceType.Name)).IsRequired().HasMaxLength(SupplierServiceTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(SupplierServiceType.Description)).HasMaxLength(SupplierServiceTypeConsts.DescriptionMaxLength);
                });
    }
}