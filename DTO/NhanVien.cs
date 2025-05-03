using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int MaNV {  get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoai { get; set; }
        public string Email {  get; set; }
        public NhanVien(int maNV, string tenNV, string chucVu, string soDienThoai, string email) 
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.ChucVu = chucVu;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
        }

        public NhanVien(string tenNV, string chucVu, string soDienThoai, string email)
        {
            this.TenNV = tenNV;
            this.ChucVu = chucVu;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
        }
    }
}
