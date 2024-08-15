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

            entity.HasIndex(e => e.Id, "AGENT_IDX1");



            entity.Property(e => e.BienSo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BIEN_SO")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.HoVaTen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HO_VA_TEN")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.DiaChi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIA_CHI")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.NgayRa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NGAY_RA")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.NgayVao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NGAY_VAO")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.LoaiPhuongTien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOAI_PHUONG_TIEN")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHUONG_THUC_THANH_TOAN")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();
            entity.Property(e => e.Flg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FLG")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();



        }
    }
}
