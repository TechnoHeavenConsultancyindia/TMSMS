using TMSMS.AgentService.AgentServices;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace TMSMS.AgentService.Data;

[ConnectionStringName(DatabaseName)]
public class AgentServiceDbContext :
    AbpDbContext<AgentServiceDbContext>,
    IHasEventInbox,
    IHasEventOutbox
{
    public DbSet<AgentFinanceDetail> AgentFinanceDetails { get; set; } = null!;
    public DbSet<AgentVoucherType> AgentVoucherTypes { get; set; } = null!;
    public DbSet<AgentPermissionType> AgentPermissionTypes { get; set; } = null!;
    public DbSet<AgentGroupType> AgentGroupTypes { get; set; } = null!;
    public const string DbTablePrefix = "";
    public const string DbSchema = null;

    public const string DatabaseName = "AgentService";

    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public AgentServiceDbContext(DbContextOptions<AgentServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();
        builder.Entity<AgentGroupType>(b =>
                {
                    b.ToTable(DbTablePrefix + "AgentGroupTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(AgentGroupType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(AgentGroupType.Name)).IsRequired().HasMaxLength(AgentGroupTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(AgentGroupType.Description)).HasMaxLength(AgentGroupTypeConsts.DescriptionMaxLength);
                });
        builder.Entity<AgentPermissionType>(b =>
                {
                    b.ToTable(DbTablePrefix + "AgentPermissionTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(AgentPermissionType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(AgentPermissionType.Name)).IsRequired().HasMaxLength(AgentPermissionTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(AgentPermissionType.Description)).HasMaxLength(AgentPermissionTypeConsts.DescriptionMaxLength);
                });
        builder.Entity<AgentVoucherType>(b =>
                {
                    b.ToTable(DbTablePrefix + "AgentVoucherTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(AgentVoucherType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(AgentVoucherType.Name)).IsRequired().HasMaxLength(AgentVoucherTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(AgentVoucherType.Description)).HasMaxLength(AgentVoucherTypeConsts.DescriptionMaxLength);
                });
        builder.Entity<AgentFinanceDetail>(b =>
                {
                    b.ToTable(DbTablePrefix + "AgentFinanceDetails", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(AgentFinanceDetail.TenantId));
                    b.Property(x => x.CreditLimit).HasColumnName(nameof(AgentFinanceDetail.CreditLimit));
                    b.Property(x => x.CreditLimitCurrency).HasColumnName(nameof(AgentFinanceDetail.CreditLimitCurrency)).HasMaxLength(AgentFinanceDetailConsts.CreditLimitCurrencyMaxLength);
                    b.Property(x => x.DisplayCurrency).HasColumnName(nameof(AgentFinanceDetail.DisplayCurrency)).HasMaxLength(AgentFinanceDetailConsts.DisplayCurrencyMaxLength);
                    b.Property(x => x.OutstandingBalance).HasColumnName(nameof(AgentFinanceDetail.OutstandingBalance));
                    b.Property(x => x.ConvertedBalance).HasColumnName(nameof(AgentFinanceDetail.ConvertedBalance));
                    b.Property(x => x.LastConversionRate).HasColumnName(nameof(AgentFinanceDetail.LastConversionRate));
                });
    }
}