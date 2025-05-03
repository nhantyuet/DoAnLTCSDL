using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDonHang
    {
        public int MaCTDH {  get; set; }
        public int MaDH {  get; set; }
        public int MaVL { get; set; }
        public int GiaBan { get; set; }
        public int Soluong {  get; set; }
        public int ThanhTien { get; set; }
        public ChiTietDonHang(int maCTDH, int maDH, int maVL, int giaBan, int soLuong)
        {
            this.MaCTDH =maCTDH;
            this.MaDH =maDH;
            this.MaVL =maVL;
            this.GiaBan =giaBan;    
            this.Soluong =soLuong;
            this.ThanhTien = giaBan * soLuong;
        }
        public ChiTietDonHang(int maDH, int maVL, int giaBan, int soLuong)
        {
            this.MaDH = maDH;
            this.MaVL = maVL;
            this.GiaBan = giaBan;
            this.Soluong = soLuong;
            this.ThanhTien = giaBan * soLuong;
        }

    }
}
