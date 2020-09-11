using KikaItems.Contracts.Entities;
using KikaItems.Contracts.Utils;
using Microsoft.EntityFrameworkCore;

namespace KikaItems.Contracts
{
    public partial class KikaDatabaseContext : DbContext
    {
        public KikaDatabaseContext()
        {
        }

        public KikaDatabaseContext(DbContextOptions<KikaDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemEntity> Items { get; set; }
        public virtual DbSet<PriceEntity> Prices { get; set; }
        public virtual DbSet<UnitsOfMeasureEntity> UnitsOfMeasure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemEntity>(entity =>
            {
                entity.HasKey(e => e.Sku);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasColumnName("EAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PriceEntity>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ItemSku)
                    .IsRequired()
                    .HasColumnName("ItemSKU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<UnitsOfMeasureEntity>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
