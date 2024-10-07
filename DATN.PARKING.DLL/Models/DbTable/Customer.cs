using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Customer
    {
        [Key]
        public int? CustomerId { get; set; } // Primary Key
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? CCCD { get; set; }
        public string? RFID { get; set; }
        public int? FingerprintData { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
        public virtual ICollection<CardAssignment>? CardAssignments { get; set; }

        // Constructor to initialize collections
        public Customer()
        {
            Vehicles = new HashSet<Vehicle>();
            CardAssignments = new HashSet<CardAssignment>();
        }
    }
}
