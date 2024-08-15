using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.PARKING.DLL.Models.DbTable
{
    public class Information
    {
        public int Id {get; set; }
        public string BienSo { get; set; }
        public string HoVaTen { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayRa { get; set; }
        public DateTime NgayVao { get; set; }
        public string LoaiPhuongTien { get; set; }
        public string PhuongThucThanhToan {  get; set; }
        public string Flg {  get; set; }

    }
}
