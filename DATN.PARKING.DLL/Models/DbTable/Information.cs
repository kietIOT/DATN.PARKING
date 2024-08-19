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
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string LoaiThanhVien { get; set; }
        public int Diem { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string TenPhuongTien { get; set; }
        public string BienSoXe { get; set; }
        public DateTime NgayRa { get; set; }
        public DateTime NgayVao { get; set; }
        public string Status { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public double TienTra { get; set; }
        public double TienKhachTra { get; set; }
    }
}
