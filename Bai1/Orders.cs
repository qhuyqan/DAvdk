using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime ThoiGian { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public double KhoiLuong { get; set; }
        public int DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
