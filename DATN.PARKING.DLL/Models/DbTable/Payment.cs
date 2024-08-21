using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Payment
    {
        public int PaymentId { get; set; } 
        public string PhuongThucThanhToan { get; set; }
        public double TienTra { get; set; }
        public double TienKhachTra { get; set; }
        public string TenPhuongTien {  get; set; }
        public DateTime NgayThanhToan { get; set; }

    }
}
