using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATN.PARKING.DLL.Infrastructure.EntityConfigurations
{
    public class InformationEntityConfigurations : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> entity)
        {
            entity.HasNoKey();

            entity.ToTable("INFORMATION");

            entity.HasIndex(e => e.InfomationId, "AGENT_IDX1");



            entity.Property(e => e.HoVaTen)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("HO_VA_TEN")
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
            entity.Property(e => e.TenPhuongTien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEN_PHUONG_TIEN")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.BienSoXe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BIEN_SO_XE")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
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
        }
    }
}
