using Microsoft.EntityFrameworkCore;

namespace KoiDeliveryOrderSystem.Models;

public partial class Fa24Se1877211G3KoiDeliveryOrderSystemContext : DbContext
{
    private readonly IConfiguration _configuration;
    public Fa24Se1877211G3KoiDeliveryOrderSystemContext(DbContextOptions<Fa24Se1877211G3KoiDeliveryOrderSystemContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Declaration> Declarations { get; set; }

    public virtual DbSet<Fish> Fish { get; set; }

    public virtual DbSet<FishCategory> FishCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var connectionStr = _configuration.GetConnectionString("DB");
            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("CompanyID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CompanyName).HasMaxLength(250);
            entity.Property(e => e.ContactPersonEmail).HasMaxLength(250);
            entity.Property(e => e.ContactPersonName).HasMaxLength(250);
            entity.Property(e => e.ContactPersonPhone).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.TaxCode).HasMaxLength(250);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.ToTable("Customer");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(250);
        });

        modelBuilder.Entity<Declaration>(entity =>
        {
            entity.ToTable("Declaration");

            entity.Property(e => e.DeclarationId)
                .ValueGeneratedNever()
                .HasColumnName("DeclarationID");
            entity.Property(e => e.ArrivalPort).HasMaxLength(250);
            entity.Property(e => e.CompanyName).HasMaxLength(250);
            entity.Property(e => e.DeparturePort).HasMaxLength(250);
            entity.Property(e => e.ExporterId).HasColumnName("ExporterID");
            entity.Property(e => e.GoodsDescription).HasMaxLength(250);
            entity.Property(e => e.Hscode)
                .HasMaxLength(250)
                .HasColumnName("HSCode");
            entity.Property(e => e.ImporterId).HasColumnName("ImporterID");
            entity.Property(e => e.ShippingMethod).HasMaxLength(50);
            entity.Property(e => e.TaxCode).HasMaxLength(250);
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.Property(e => e.FishId).ValueGeneratedNever();
            entity.Property(e => e.Breed).HasMaxLength(250);
            entity.Property(e => e.Color).HasMaxLength(250);
            entity.Property(e => e.Environment).HasMaxLength(250);
            entity.Property(e => e.FishTypeId).HasColumnName("FishTypeID");
            entity.Property(e => e.Food).HasMaxLength(250);
            entity.Property(e => e.Illness).HasMaxLength(250);
            entity.Property(e => e.SharpBody).HasMaxLength(250);

            entity.HasOne(d => d.FishType).WithMany(p => p.Fish)
                .HasForeignKey(d => d.FishTypeId)
                .HasConstraintName("FK_Fish_FishCategory");
        });

        modelBuilder.Entity<FishCategory>(entity =>
        {
            entity.HasKey(e => e.FishTypeId);

            entity.ToTable("FishCategory");

            entity.Property(e => e.FishTypeId).HasColumnName("FishTypeID");
            entity.Property(e => e.Breed).HasMaxLength(250);
            entity.Property(e => e.FishName).HasMaxLength(250);
            entity.Property(e => e.Origin).HasMaxLength(250);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AddressFrom).HasMaxLength(250);
            entity.Property(e => e.AddressTo).HasMaxLength(250);
            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.Health).HasMaxLength(250);
            entity.Property(e => e.Others).HasMaxLength(250);
            entity.Property(e => e.PaymentMethod).HasMaxLength(250);
            entity.Property(e => e.Status).HasMaxLength(250);
            entity.Property(e => e.TranportBy).HasMaxLength(250);

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.Certificate).HasMaxLength(250);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.DeclarationId).HasColumnName("DeclarationID");
            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.Health).HasMaxLength(250);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.SetUp).HasMaxLength(250);

            entity.HasOne(d => d.Declaration).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.DeclarationId)
                .HasConstraintName("FK_OrderDetail_Declaration");

            entity.HasOne(d => d.Fish).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.FishId)
                .HasConstraintName("FK_OrderDetail_Fish");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
