using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Vehicle
    {
        [Key]
        public int? VehicleId { get; set; }
        public string? LicensePlate { get; set; }
        public string? VehicleType { get; set; }

        public int? CustomerId { get; set; } // Foreign key property

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<ParkingSession>? ParkingSessions { get; set; }

        // Constructor to initialize collections
        public Vehicle()
        {
            ParkingSessions = new HashSet<ParkingSession>();
        }
    }

}
