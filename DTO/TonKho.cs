using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TonKho
    {
        public int MaVL {  get; set; }
        public int SoLuongTon {  get; set; }
        public TonKho(int maVL, int soLuongTon)
        {
            this.MaVL = maVL;
            this.SoLuongTon = soLuongTon;
        }   
    }
}
