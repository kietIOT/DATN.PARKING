using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCIS.TTOS.EDI.DAL.Infrastructure.EntityConfigurations
{
    public class AccountEntityConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Account");

            entity.HasIndex(e => e.id, "AGENT_IDX1");



            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserName")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PassWord")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            
        }
    }
}
