using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Information
    {
        public int InfomationId {get; set; }
        public Customer KhachHang { get; set; }
        public Vehicle PhuongTien { get; set; }
        public PaymentMethod PhuongThucThanhToan {  get; set; }
        public Payment ThanhToan { get; set; }
    }
}
