using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class CardType
    {
        [Key]
        public int? CardTypeId { get; set; }
        public string? CardTypeName { get; set; }

        public virtual ICollection<CardAssignment>? CardAssignments { get; set; } = new List<CardAssignment>();
    }

}
