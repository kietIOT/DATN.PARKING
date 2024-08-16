using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATN.PARKING.DLL.Infrastructure.EntityConfigurations
{
    public class PaymentMethodEntityConfigurations : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.HasNoKey();

            entity.ToTable("PAYMENT_METHOD");

            entity.HasIndex(e => e.PaymentMethodId, "AGENT_IDX1");



            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHUONG_THUC_THANH_TOAN")
                .HasDefaultValueSql("' ' ");

        }
    }
}
