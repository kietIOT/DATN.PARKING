using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class CardAssignment
    {
        [Key]
        public int? CardAssignmentId { get; set; }

        public int? CustomerId { get; set; }
        public int? CardTypeId { get; set; }
        public string? CardValue { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("CardTypeId")]
        public virtual CardType? CardType { get; set; }
    }

}
