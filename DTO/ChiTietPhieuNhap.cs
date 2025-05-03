using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuNhap
    {
        public int MaPhieuNhap {  get; set; }
        public int MaVL {  get; set; }
        public int SoLuong { get; set; }
        public int GiaNhap { get; set; }
        public ChiTietPhieuNhap(int maPhieuNhap, int maVL, int soLuong, int giaNhap)
        {
            MaPhieuNhap = maPhieuNhap;
            MaVL = maVL;
            SoLuong = soLuong;
            GiaNhap = giaNhap;
        }
        public ChiTietPhieuNhap(int maVL, int soLuong, int giaNhap)
        {
            MaVL = maVL;
            SoLuong = soLuong;
            GiaNhap = giaNhap;
        }
    }
}
