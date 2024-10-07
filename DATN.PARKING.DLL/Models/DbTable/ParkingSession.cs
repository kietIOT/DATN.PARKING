using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class ParkingSession
    {
        [Key]
        public int? SessionId { get; set; }

        public int? ParkingSlotId { get; set; }
        public int? VehicleId { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; } // Nullable if the vehicle hasn't exited yet
        public decimal? PaymentAmount { get; set; }
        public bool? IsPaid { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle? Vehicle { get; set; }

        public virtual Payment? Payment { get; set; }

        [ForeignKey("ParkingSlotId")]
        public virtual ParkingSlot? ParkingSlot { get; set; }
    }

}
