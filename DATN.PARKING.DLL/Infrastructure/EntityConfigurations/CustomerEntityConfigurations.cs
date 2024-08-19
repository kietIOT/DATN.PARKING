using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATN.PARKING.DLL.Infrastructure.EntityConfigurations
{
    public class CustomerEntityConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasNoKey();

            entity.ToTable("CUSTOMER");

            entity.HasIndex(e => e.KhachHangId, "AGENT_IDX1");



            entity.Property(e => e.HoVaTen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HO_VA_TEN")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.CCCD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCCD")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SO_DIEN_THOAI")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.LoaiThanhVien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOAI_THANH_VIEN")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.Diem)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIEM")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.DiaChi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIA_CHI")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.NgayDangKy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NGAY_DANG_KY")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();



        }
    }
}
