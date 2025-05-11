using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichSuCongNo
    {
        public int MaLSCN {  get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public int SoTien { get; set; }
        public DateTime ThoiGian { get; set; }
        public LichSuCongNo(int maLSCN, int maKH, int maNV, int soTien, DateTime thoiGian)
        {
            MaLSCN = maLSCN;
            MaKH = maKH;
            MaNV = maNV;
            SoTien = soTien;
            ThoiGian = thoiGian;
        }
        public LichSuCongNo(int maKH, int maNV, int soTien, DateTime thoiGian)
        {
            MaKH = maKH;
            MaNV = maNV;
            SoTien = soTien;
            ThoiGian = thoiGian;
        }

    }
}
