using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Payment
    {
        [Key]
        public int? PaymentId { get; set; }

        public int? SessionId { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }

        [ForeignKey("SessionId")]
        public virtual ParkingSession? ParkingSession { get; set; }
    }

}
