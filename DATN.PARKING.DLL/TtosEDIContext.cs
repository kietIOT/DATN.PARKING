using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using TCIS.TTOS.Commons;
using TCIS.TTOS.EDI.DAL.Models.DbTable;

namespace TCIS.TTOS.EDI.DAL
{
    public class TtosEDIContext : DbContext, ITtosEDIContext
    {
        public DbSet<EdiCoparnMsgIntf> EdiCoparnMsgIntfs { get; set; }


        public TtosEDIContext()
        {

        }

        public TtosEDIContext(DbContextOptions<TtosEDIContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
        }

        private ModelBuilder TablleKeyConfiguration(ModelBuilder modelBuilder)
        {
            return modelBuilder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder = TablleKeyConfiguration(modelBuilder);
            modelBuilder = SequenceConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private ModelBuilder SequenceConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EdiCoparnMsgIntf>(i => { i.HasKey(s => new { s.Id }); });
   
    
            return modelBuilder;
        }


        public virtual async Task<int> SaveAsync()
        {
            return SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            foreach (var entity in this.ChangeTracker.Entries())
            {
                foreach (PropertyEntry property in entity.Properties.ToList().Where(o => !o.Metadata.IsKey()))
                    TrimFieldValue(property);
            }
            return SaveChanges();
        }

        private void TrimFieldValue(PropertyEntry property)
        {
            if (property.Metadata.ClrType.Name == "String")
            {
                property.CurrentValue = property.CurrentValue.TrimEx().IsNullOrEmpty() ? string.Empty : property.CurrentValue.TrimEx();
            }
        }
    }
}
