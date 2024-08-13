using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCIS.TTOS.EDI.DAL.Infrastructure.EntityConfigurations
{
    public class AgentEntityConfigurations : IEntityTypeConfiguration<Agents>
    {
        public void Configure(EntityTypeBuilder<Agents> entity)
        {
            entity.HasNoKey();

            entity.ToTable("AGENT");

            entity.HasIndex(e => e.Agent, "AGENT_IDX1");

            entity.HasIndex(e => new { e.LineOper, e.SiteId }, "AGENT_IDX2");

            entity.HasIndex(e => new { e.Agent, e.LineOper, e.ExpiryTs }, "AGENT_IDX3");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.Agent)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("AGENT")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.AsAtTs)
                .HasColumnType("DATE")
                .HasColumnName("AS_AT_TS")
                .HasDefaultValueSql("TO_DATE ('31/12/1900 23:00','dd/mm/yyyy hh24:mi')");

            entity.Property(e => e.ChargeCodes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CHARGE_CODES")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.ChargeType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CHARGE_TYPE")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.ContType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CONT_TYPE")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.ExpiryTs)
                .HasColumnType("DATE")
                .HasColumnName("EXPIRY_TS")
                .HasDefaultValueSql("TO_DATE ('31/12/1900 23:00','dd/mm/yyyy hh24:mi')");

            entity.Property(e => e.Fel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FEL")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME")
                .HasDefaultValueSql("' ' ");

            entity.Property(e => e.IsBillAgent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("IS_BILL_AGENT")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.IsContAgent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("IS_CONT_AGENT")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.LineOper)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("LINE_OPER")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.LinePrintSeparate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LINE_PRINT_SEPARATE")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE")
                .HasDefaultValueSql("' ' ")
                .IsFixedLength();

            entity.Property(e => e.SiteId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("SITE_ID")
                .HasDefaultValueSql("'TOS' ")
                .IsFixedLength();

            entity.Property(e => e.UpdTs)
                .HasColumnType("DATE")
                .HasColumnName("UPD_TS")
                .HasDefaultValueSql("SYSDATE ");
        }
    }
}
