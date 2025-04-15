using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public KhachHang(int MaKH, string TenKH, string DiaChi, string SDT) 
        {
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
        }
        public KhachHang()
        {
        }
    }
}
