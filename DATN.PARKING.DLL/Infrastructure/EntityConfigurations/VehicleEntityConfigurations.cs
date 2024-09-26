using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATN.PARKING.DLL.Infrastructure.EntityConfigurations
{
    public class VehicleEntityConfigurations : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            entity.HasNoKey();

            entity.ToTable("VEHICLE");

            entity.HasIndex(e => e.VehicleId, "AGENT_IDX1");


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




        }
    }
}
