using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;
using DAO;
using System.Security.Policy;
namespace DTO
{
    public class ucBieuDoDoanhThuDL:DataProvider
    {
        public SqlDataReader TinhGiaNhapTrungBinhDL(int maVL)
        {
            string sql = $@"SELECT SUM(ctpn.GiaNhap * ctpn.SoLuong) AS TongGiaNhap,SUM(ctpn.SoLuong) AS TongSoLuong
                           FROM ChiTietPhieuNhap ctpn
                           WHERE ctpn.MaVL = {maVL}";
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                return reader;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
   
    }

}
