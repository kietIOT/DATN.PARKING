using DATN.PARKING.DLL.Models.DbTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.Dtos
{
    public class ViewInformationCustomer
    {
        public string HoVaTen { get; set; }
        public string CCCD { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string LoaiThanhVien { get; set; } // Ví dụ: Regular, VIP
        public int Diem { get; set; } // Điểm tích lũy nếu có chương trình khách hàng thân thiết
        public string DiaChi { get; set; }
        public string TenPhuongTien { get; set; }
        public string BienSoXe { get; set; }
        public DateTime NgayRa { get; set; }
        public DateTime NgayVao { get; set; }
        public double TienKhachTra { get; set; }
        public string PhuongThucThanhToan {  get; set; }
    }
}
