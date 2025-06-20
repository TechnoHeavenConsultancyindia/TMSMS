using TMSMS.TransferService.TransferServices;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace TMSMS.TransferService.Data;

[ConnectionStringName(DatabaseName)]
public class TransferServiceDbContext :
    AbpDbContext<TransferServiceDbContext>,
    IHasEventInbox,
    IHasEventOutbox
{
    public DbSet<TransferType> TransferTypes { get; set; } = null!;
    public const string DbTablePrefix = "";
    public const string DbSchema = null;

    public const string DatabaseName = "TransferService";

    public DbSet<IncomingEventRecord> IncomingEvents { get; set; }
    public DbSet<OutgoingEventRecord> OutgoingEvents { get; set; }

    public TransferServiceDbContext(DbContextOptions<TransferServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEventInbox();
        builder.ConfigureEventOutbox();
        builder.Entity<TransferType>(b =>
                {
                    b.ToTable(DbTablePrefix + "TransferTypes", DbSchema);
                    b.ConfigureByConvention();
                    b.Property(x => x.TenantId).HasColumnName(nameof(TransferType.TenantId));
                    b.Property(x => x.Name).HasColumnName(nameof(TransferType.Name)).IsRequired().HasMaxLength(TransferTypeConsts.NameMaxLength);
                    b.Property(x => x.Description).HasColumnName(nameof(TransferType.Description));
                });
    }
}