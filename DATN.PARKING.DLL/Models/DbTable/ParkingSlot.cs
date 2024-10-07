using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class ParkingSlot
    {
        [Key]
        public int? SlotId { get; set; }
        public string? SlotNumber { get; set; }
        public bool? IsOccupied { get; set; }

        public virtual ICollection<ParkingSession>? ParkingSessions { get; set; } = new List<ParkingSession>();
    }

}
