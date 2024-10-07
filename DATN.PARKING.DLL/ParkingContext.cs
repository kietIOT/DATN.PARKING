using DATN.PARKING.DLL.Models.DbTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace DATN.PARKING.DLL
{
    public class ParkingContext : DbContext, ITtosEDIContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardAssignment> CardAssignments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public ParkingContext()
        {

        }

        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=TCIS-SSC-37128D\\SQLEXPRESS;Initial Catalog=DATN.PARKING;TrustServerCertificate=True;Trusted_Connection=True;");
            }
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

            modelBuilder.Entity<Customer>()
                    .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Vehicle>()
                    .HasKey(v => v.VehicleId);

            modelBuilder.Entity<Account>()
                         .HasKey(c => c.Id);

            modelBuilder.Entity<Vehicle>()
                    .HasOne(v => v.Customer)
                   .WithMany(c => c.Vehicles)
                   .HasForeignKey(v => v.CustomerId); // Specify the foreign key

            modelBuilder.Entity<CardAssignment>()
                       .HasOne(ca => ca.Customer)
                       .WithMany(c => c.CardAssignments)
                       .HasForeignKey(ca => ca.CustomerId);

            modelBuilder.Entity<CardAssignment>()
                .HasOne(ca => ca.CardType)
                .WithMany(ct => ct.CardAssignments)
                .HasForeignKey(ca => ca.CardTypeId);

            // Configure other relationships if necessary
            modelBuilder.Entity<ParkingSession>()
                .HasOne(ps => ps.Vehicle)
                .WithMany(v => v.ParkingSessions)
                .HasForeignKey(ps => ps.VehicleId);

            modelBuilder.Entity<ParkingSession>()
                .HasOne(ps => ps.ParkingSlot)
                .WithMany(psl => psl.ParkingSessions)
                .HasForeignKey(ps => ps.ParkingSlotId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.ParkingSession)
                .WithOne(ps => ps.Payment)
                .HasForeignKey<Payment>(p => p.SessionId);

            base.OnModelCreating(modelBuilder);
        }

        private ModelBuilder SequenceConfiguration(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EdiCoparnMsgIntf>(i => { i.HasKey(s => new { s.Id }); });


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
                //property.CurrentValue = property.CurrentValue.TrimEx().IsNullOrEmpty() ? string.Empty : property.CurrentValue.TrimEx();
            }
        }
    }
}
