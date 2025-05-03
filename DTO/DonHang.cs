using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class DonHang
    {
        public int MaDH  {  get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public string NgayDatHang { get; set; }
        public string NgayGiaoHang { get; set; }
        public string DiaChi {  get; set; }
        public string SoDienThoai {  get; set; }
        public DonHang(int maDH, int maKH, int maNV, string ngayDatHang, string ngayGiaoHang, string diaChi, string soDienThoai) 
        {
            this.MaDH = maDH;
            this.MaKH = maKH;
            this.MaNV = maNV;
            this.NgayDatHang = ngayDatHang;
            this.NgayGiaoHang = ngayGiaoHang;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
        }
        public DonHang(int maKH, int maNV, string ngayDatHang, string ngayGiaoHang, string diaChi, string soDienThoai)
        {
            this.MaKH = maKH;
            this.MaNV = maNV;
            this.NgayDatHang = ngayDatHang;
            this.NgayGiaoHang = ngayGiaoHang;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
        }
    }
}
