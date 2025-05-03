using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap
    {
        public int MaPhieuNhap {  get; set; }
        public string TrangThai { get; set; }
        public string NgayNhap { get; set; }
        public int TongTien { get; set; }
        public PhieuNhap(int maPhieuNhap, string trangThai, string ngayNhap, int tongTien)
        {
            MaPhieuNhap = maPhieuNhap;
            TrangThai = trangThai;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
        }
        public PhieuNhap(string trangThai, string ngayNhap, int tongTien)
        {
           
            TrangThai = trangThai;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
        }
    }
}
