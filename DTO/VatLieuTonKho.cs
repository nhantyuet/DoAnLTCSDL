using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VatLieuTonKho
    {
        public int MaVL { get; set; }
        public string TenVL { get; set; }
        public string DonViTinh { get; set; }
        public int GiaBan { get; set; }

        public int SoLuongTon { get; set; }

        public VatLieuTonKho(int maVL, string tenVL, string donViTinh, int giaBan, int soLuongTon)
        {
            MaVL = maVL;
            TenVL = tenVL;
            DonViTinh = donViTinh;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }
        public VatLieuTonKho(string tenVL, string donViTinh, int giaBan, int soLuongTon)
        {
            TenVL = tenVL;
            DonViTinh = donViTinh;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }
    }
}
