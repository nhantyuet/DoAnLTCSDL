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
        public string Email {  get; set; } 
        public int CongNo { get; set; }

        public KhachHang(int maKH, string tenKH, string diaChi, string soDienThoai, string email, int congNo)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.DiaChi = diaChi;
            this.SDT = soDienThoai;
            this.Email = email;
            this.CongNo = congNo;
        }
        public KhachHang(string tenKH, string diaChi, string soDienThoai, string email, int congNo)
        {
            this.TenKH = tenKH;
            this.DiaChi = diaChi;
            this.SDT = soDienThoai;
            this.Email = email;
            this.CongNo = congNo;
        }
        public KhachHang() 
        {
        }

    }
}
