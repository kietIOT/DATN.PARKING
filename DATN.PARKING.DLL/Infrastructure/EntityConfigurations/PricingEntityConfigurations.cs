using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATN.PARKING.DLL.Infrastructure.EntityConfigurations
{
    public class PricingEntityConfigurations : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> entity)
        {
            entity.HasNoKey();

            entity.ToTable("PRICING");

            entity.HasIndex(e => e.PricingId, "AGENT_IDX1");



            entity.Property(e => e.TenPhuongTien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEN_PHUONG_TIEN")
                .HasDefaultValueSql("' ' ");


            entity.Property(e => e.NgayRa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NGAY_RA")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.NgayVao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NGAY_VAO")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.Status)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("STATUS")
               .HasDefaultValueSql("' ' ")
               .IsFixedLength();


            entity.Property(e => e.PricePerHour)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRICE_PER_HOUR")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.PricePerDay)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRICE_PER_DAY")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.PricePerMonth)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRICE_PER_MONTH")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();


            entity.Property(e => e.Discount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DISCOUNT")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();



        }
    }
}
