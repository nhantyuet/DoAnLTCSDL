using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VatLieu
    {
        public int MaVL {  get; set; }
        public string TenVL { get; set; }
        public string DonViTinh { get; set; }
        public int GiaBan {  get; set; }
        public VatLieu(int maVL, string tenVL, string donViTinh, int giaBan)
        {
            this.MaVL = maVL;
            this.TenVL = tenVL;
            this.DonViTinh = donViTinh;
            this.GiaBan = giaBan;
        }


    }
}
