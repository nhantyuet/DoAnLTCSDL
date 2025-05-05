using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonKH
    {
        public int MaHD { get; set; }
        public int MaDH { get; set; }
        public int MaKH { get; set; }
        public string NgayLap { get; set; }
        public int TongTien { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public HoaDonKH(int maHD,int maDH,int maKH, string ngayLap, int tongTien, string trangThaiThanhToan)
        {
            this.MaHD = maHD;
            this.MaDH = maDH;
            this.MaKH = maKH;
            this.NgayLap = ngayLap;
            this.TongTien = tongTien;
            this.TrangThaiThanhToan = trangThaiThanhToan;
        }
    }
}
