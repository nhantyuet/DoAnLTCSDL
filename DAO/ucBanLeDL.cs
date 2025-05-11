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
    public class ucBanLeDL : DataProvider
    {
        public  KhachHang timKiemKhachHangDL(string SDT)
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

        public List<VatLieuTonKho> GetVatLieuTonKhoDL()
        {
            string tenVL, donViTinh;
            List<VatLieuTonKho> vatLieuTonKhos = new List<VatLieuTonKho>();
            int giaBan, soLuongTon;
            string sql = "select VatLieu.TenVL , VatLieu.GiaBan, TonKho.SoLuongTon, VatLieu.DonViTinh\r\nfrom VatLieu join TonKho \r\non VatLieu.MaVL = TonKho.MaVL";
            try 
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while(reader.Read())
                {
                    tenVL = reader[0].ToString();
                    giaBan = Int32.Parse( reader[1].ToString());
                    soLuongTon = Int32.Parse(reader[2].ToString());
                    donViTinh = reader[3].ToString();
                    VatLieuTonKho vatLieuTonKho = new VatLieuTonKho(tenVL, donViTinh, giaBan, soLuongTon);
                    vatLieuTonKhos.Add(vatLieuTonKho);
                }
                reader.Close();
                return vatLieuTonKhos;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public int themKhachHangDL(KhachHang kh) //co 3 cach lun 
        {
            string sql = $"INSERT INTO[dbo].[KhachHang]([TenKH], [DiaChi], [SoDienThoai]) " +
                               $"VALUES('{kh.TenKH}','{kh.DiaChi}','{kh.SDT}')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;   
            }
        }
        public int insertDonHangDL(DonHang donHang)
        {
            try
            {
                Connect();
                string sql = $"INSERT INTO[dbo].[DonHang]([MaKH],[MaNV],[NgayDatHang],[NgayGiaoHang],[DiaChi],[SoDienThoai]) " +
                                "VALUES(@MaKH,@MaNV,@NgayDatHang,@NgayGiaoHang,@DiaChi,@SoDienThoai);" +
                                "select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@MaKH", donHang.MaKH);
                cmd.Parameters.AddWithValue("@MaNV", donHang.MaNV);
                cmd.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                cmd.Parameters.AddWithValue("@NgayGiaoHang", donHang.NgayGiaoHang);
                cmd.Parameters.AddWithValue("@DiaChi", donHang.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", donHang.SoDienThoai);
                return Int32.Parse(cmd.ExecuteScalar().ToString());
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
        public int ThemChiTietDonHangDL(ChiTietDonHang chiTietDonHang)
        {
            
            
            try
            {
                Connect();
                string sql = $"INSERT INTO [dbo].[ChiTietDonHang]([MaDH],[MaVL],[GiaBan],[SoLuong])\r\n" +
                $"VALUES({chiTietDonHang.MaDH},{chiTietDonHang.MaVL},{chiTietDonHang.GiaBan},{chiTietDonHang.Soluong})"+
                "select SCOPE_IDENTITY();";
                return Int32.Parse(MyExecuteScalar(sql, CommandType.Text).ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        /* public int insertDonHangDL(string MaKH, string MaNV, string NgayDatHang, string NgayGiaoHang, string DiaChi, string SoDienThoai)
         {
             string sql = $"INSERT INTO[dbo].[DonHang]([MaKH],[MaNV],[NgayDatHang],[NgayGiaoHang],[DiaChi],[SoDienThoai]) " +
                                 $"VALUES('{MaKH}','{MaNV}','{NgayDatHang}','{NgayGiaoHang}','{DiaChi}','{SoDienThoai}');" +
                                 "select SCOPE_IDENTITY();";
             try
             {
                 return MyExecuteNonQuery(sql, CommandType.Text);
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
         }
        */
        public int insertHoaDonDL(HoaDon hoaDon)
        {
            string sql = $"INSERT INTO [dbo].[HoaDon]([MaDH],[NgayLap],[TongTien],[TrangThaiThanhToan])" +
                $"VALUES({hoaDon.MaDH},'{hoaDon.NgayLap}',{hoaDon.TongTien},'{hoaDon.TrangThaiThanhToan}')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        /*public int insertHoaDonDL(int MaDH, string ngayLap, int tongTien, string trangThaiThanhToan)
        {
            string sql = $"INSERT INTO [dbo].[HoaDon]([MaDH],[NgayLap],[TongTien],[TrangThaiThanhToan])" +
                $"VALUES('{MaDH}','{ngayLap}','{tongTien}','{trangThaiThanhToan}')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        */

        public int ThemCongNoDL(string SoDienThoai, int TienNo)
        {
            string sql = $"Update KhachHang set CongNo = CongNo + {TienNo} where SoDienThoai = '{SoDienThoai}'";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int TonKhoDL(int MaVL, int SoLuongBan)
        {
            string sql = $"Update TonKho set SoLuongTon = SoLuongTon - {SoLuongBan} where MaVL = '{MaVL}'";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemLichSuCongNoDL(LichSuCongNo lichSuCongNo)
        {
            string sql = $"insert into [dbo].[LichSuCongNo]([MaKH],[MaNV],[SoTien],[ThoiGian])\r\n" +
                $"VALUES ({lichSuCongNo.MaKH},{lichSuCongNo.MaNV},{lichSuCongNo.SoTien},'{lichSuCongNo.ThoiGian}')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        

        public int insertThemLichSuCongNoDL(string SoDienThoai, int TienNo)
        {
            string sql = $"Update KhachHang set CongNo = CongNo + '{TienNo}' where SoDienThoai = '{SoDienThoai}'";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public List<VatLieuTonKho> tinKiemSanPhamDL(string tenVLInPut)
        {
            string donViTinh, tenVL;
            List<VatLieuTonKho> vatLieuTonKhos = new List<VatLieuTonKho>();
            int giaBan, soLuongTon;
            string sql = "select VatLieu.TenVL , VatLieu.GiaBan, TonKho.SoLuongTon, VatLieu.DonViTinh\r\nfrom VatLieu join TonKho \r\non VatLieu.MaVL = TonKho.MaVL " +
                  "WHERE TenVL LIKE N'%" + tenVLInPut + "%'";
            try
            {
               Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    tenVL = reader[0].ToString();
                    giaBan = Int32.Parse(reader[1].ToString());
                    soLuongTon = Int32.Parse(reader[2].ToString());
                    donViTinh = reader[3].ToString();
                    VatLieuTonKho vatLieuTonKho = new VatLieuTonKho(tenVL, donViTinh, giaBan, soLuongTon);
                    vatLieuTonKhos.Add(vatLieuTonKho);
                }
                reader.Close();
                return vatLieuTonKhos;

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

        public string getMaVLDL(string tenVL)
        {
            string sql = $"select MaVL from VatLieu where TenVL = N'{tenVL}'";
        //    string sql = $"select MaVL from VatLieu where TenVL = 'Cát xây'";
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
