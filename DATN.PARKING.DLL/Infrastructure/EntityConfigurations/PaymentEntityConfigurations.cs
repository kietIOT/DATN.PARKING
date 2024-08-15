using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATN.PARKING.DLL.Infrastructure.EntityConfigurations
{
    public class PaymentEntityConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasNoKey();

            entity.ToTable("PAYMENT");

            entity.HasIndex(e => e.Id, "AGENT_IDX1");



            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHUONG_THUC_THANH_TOAN")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.TienTra)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIEN_TRA")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.TienKhachTra)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIEN_KHACH_TRA")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.PhuongTien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHUONG_TIEN")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
         


        }
    }
}
