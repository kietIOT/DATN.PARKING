using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public Vehicle PhuongTien { get; set; }
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }
        public double PricePerMonth { get; set; }
        public double Discount { get; set; } // Giảm giá nếu có
    }
}
