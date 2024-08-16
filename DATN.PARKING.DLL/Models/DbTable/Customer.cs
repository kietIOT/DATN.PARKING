using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Customer
    {
        public int KhachHangId { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string LoaiThanhVien { get; set; } // Ví dụ: Regular, VIP
        public int Diem { get; set; } // Điểm tích lũy nếu có chương trình khách hàng thân thiết
        public string DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; }
    }
}
