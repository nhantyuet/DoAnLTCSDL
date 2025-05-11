using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ucBieuDoDoanhThuBL
    {
        private ucBieuDoDoanhThuDL uc_BieuDoDoanhThuDL;
        public ucBieuDoDoanhThuBL()
        {
            uc_BieuDoDoanhThuDL = new ucBieuDoDoanhThuDL();
        }
        public Decimal TinhGiaNhapTrungBinhBL(int maVL)
        {
            SqlDataReader reader = uc_BieuDoDoanhThuDL.TinhGiaNhapTrungBinhDL(maVL);
            if(reader.HasRows )
            {
                while (reader.Read())
                {
                    Decimal tongGiaNhap = Convert.ToDecimal(reader[0].ToString());
                    int TongSoLuong = Convert.ToInt32(reader[1].ToString());
                    decimal giaNhapTrungBinh = Math.Round(tongGiaNhap / TongSoLuong,2);
                    return giaNhapTrungBinh;
                }
                reader.Close();
            }
            return 0;
        }
    }
}
