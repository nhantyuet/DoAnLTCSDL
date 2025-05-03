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
namespace DTO
{
    public class ucThanhToanCongNoDL:DataProvider
    {
        public KhachHang timKiemKhachHangDL(string SDT)
        {
            string sql = "select * from KhachHang where SoDienThoai = '" + SDT + "'";
            KhachHang khachHang = new KhachHang();
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    khachHang.MaKH = Int32.Parse(reader[0].ToString()); //Nên test lại consoleWrite
                    khachHang.TenKH = reader[1].ToString();//Nên test lại consoleWrite
                    khachHang.DiaChi = reader[2].ToString();//Nên test lại consoleWrite
                    khachHang.SDT = reader[3].ToString();//Nên test lại consoleWrite
                    khachHang.CongNo = Int32.Parse(reader[5].ToString());
                }
                reader.Close();
                return khachHang;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public int InsertLichSuCongNoDL(LichSuCongNo lichSuCongNo)
        {
            string sql = $"INSERT INTO [dbo].[LichSuCongNo]([MaKH],[MaNV],[SoTien],[ThoiGian])\r\n" +
                $"VALUES({lichSuCongNo.MaKH},{lichSuCongNo.MaNV},{lichSuCongNo.SoTien},'{lichSuCongNo.ThoiGian}')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdateCongNoKhachHangDL(string soDienThoai, int soTien)
        {
            string sql = $"UPDATE [dbo].[KhachHang]\r\n" +
                $"SET [CongNo] = CongNo - {soTien}\r\nWHERE SoDienThoai = '{soDienThoai}'";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string getMaKHDL(string sdt)
        {
            string sql = $"select MaKH from KhachHang where SoDienThoai = '{sdt}'";
            try
            {
                return MyExecuteScalar(sql, CommandType.Text).ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string getMaNVDL(string username)
        {
            string sql = $"select MaNV from TaiKhoan where Username = '{username}'";
            try
            {
                return MyExecuteScalar(sql, CommandType.Text).ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
