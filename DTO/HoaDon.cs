using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaDH { get; set; }
        public string NgayLap { get; set; }
        public int TongTien { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public HoaDon(int maHD, int maDH, string ngayLap, int tongTien, string trangThaiThanhToan)   
        {   
            this.MaDH = maHD;
            this.MaDH = maDH;
            this.NgayLap= ngayLap;
            this.TongTien= tongTien;
            this.TrangThaiThanhToan= trangThaiThanhToan;
        }
        public HoaDon(int maDH, string ngayLap, int tongTien, string trangThaiThanhToan)
        {
            this.MaDH = maDH;
            this.NgayLap = ngayLap;
            this.TongTien = tongTien;
            this.TrangThaiThanhToan = trangThaiThanhToan;
        }
    }
}
