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
    public class ucXuatHoaDonDL: DataProvider
    {
        public List<HoaDonKH> GetHoaDonDL()
        {
            string ngayLap, trangThaiDonHang;
            int maHD,maDH, maKH, tongTien;
            List<HoaDonKH> hoaDonKH = new List<HoaDonKH>();
            string sql = "select MaHD,HoaDon.MaDH, MaKH, NgayLap,TongTien, TrangThaiThanhToan\r\nfrom HoaDon\r\njoin DonHang on HoaDon.MaDH = DonHang.MaDH";
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    maHD = Int32.Parse(reader[0].ToString());
                    maDH = Int32.Parse(reader[1].ToString());
                    maKH = Int32.Parse(reader[2].ToString());
                    ngayLap = reader[3].ToString();
                    tongTien = Int32.Parse(reader[4].ToString());
                    trangThaiDonHang = reader[5].ToString();
                    HoaDonKH hoaDon = new HoaDonKH(maHD, maDH, maKH, ngayLap, tongTien, trangThaiDonHang);
                    hoaDonKH.Add(hoaDon);
                }
                reader.Close();
                return hoaDonKH;
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
        public List<ChiTietDonHang> GetChiTietDonHangDL(int MaDHinput)
        {
            int MaCTDH, MaDHoutput, MaVL, GiaBan, SoLuong;
            string TenVL;
            List<ChiTietDonHang> chiTietDonHangs = new List<ChiTietDonHang>();
            string sql = $"select MaCTDH, HoaDon.MaDH,ChiTietDonHang.MaVL,TenVL,ChiTietDonHang.GiaBan,ChiTietDonHang.SoLuong,ChiTietDonHang.ThanhTien \r\n " +
                $"from HoaDon join ChiTietDonHang on HoaDon.MaDH = ChiTietDonHang.MaDH\r\n " +
                $"join VatLieu on VatLieu.MaVL = ChiTietDonHang.MaVL " +
                $" where HoaDon.MaDH = {MaDHinput}";
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    MaCTDH = Int32.Parse(reader[0].ToString());
                    MaDHoutput = Int32.Parse(reader[1].ToString());
                    MaVL = Int32.Parse(reader[2].ToString());
                    TenVL = reader[3].ToString();
                    GiaBan = Int32.Parse( reader[4].ToString());
                    SoLuong = Int32.Parse(reader[5].ToString());
                    ChiTietDonHang chiTietDonHang = new ChiTietDonHang(MaCTDH, MaDHoutput, MaVL,TenVL, GiaBan, SoLuong);
                    chiTietDonHangs.Add(chiTietDonHang);
                }
                reader.Close();
                return chiTietDonHangs;
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
        public List<HoaDonKH> timKiemHoaDonSoDienThoaiDL(string soDienThoai)
        {
            string ngayLap, trangThaiDonHang;
            int maHD,maKH1,maDH, tongTien;

            List<HoaDonKH> hoaDonKH = new List<HoaDonKH>();
            string sql = $"select MaHD,DonHang.MaDH , DonHang.MaKH, NgayLap,TongTien, TrangThaiThanhToan " +
                $"from HoaDon join DonHang on HoaDon.MaDH = DonHang.MaDH " +
                $"join KhachHang on KhachHang.MaKH = DonHang.MaKH " +
                $"where KhachHang.SoDienThoai = '{soDienThoai}'";
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    maHD = Int32.Parse(reader[0].ToString());
                    maDH = Int32.Parse(reader[1].ToString());
                    maKH1 = Int32.Parse(reader[2].ToString());
                    ngayLap = reader[3].ToString();
                    tongTien = Int32.Parse(reader[4].ToString());
                    trangThaiDonHang = reader[5].ToString();
                    HoaDonKH hoaDon = new HoaDonKH(maHD,maDH, maKH1, ngayLap, tongTien, trangThaiDonHang);
                    hoaDonKH.Add(hoaDon);
                }
                reader.Close();
                return hoaDonKH;
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
        public List<HoaDonKH> timKiemHoaDonMaKHDL(int maKH)
        {
            string ngayLap, trangThaiDonHang;
            int maHD,maDH, maKH1, tongTien;
            List<HoaDonKH> hoaDonKH = new List<HoaDonKH>();
            string sql = $"select MaHD,DonHang.MaDH, MaKH, NgayLap,TongTien, TrangThaiThanhToan " +
                $"from HoaDon join DonHang on HoaDon.MaDH = DonHang.MaDH" +
                $" where MaKH ={maKH}";
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    maHD = Int32.Parse(reader[0].ToString());
                    maDH = Int32.Parse(reader[1].ToString());
                    maKH1 = Int32.Parse(reader[2].ToString());
                    ngayLap = reader[3].ToString();
                    tongTien = Int32.Parse(reader[4].ToString());
                    trangThaiDonHang = reader[5].ToString();
                    HoaDonKH hoaDon = new HoaDonKH(maHD, maDH, maKH1, ngayLap, tongTien, trangThaiDonHang);
                    hoaDonKH.Add(hoaDon);
                }
                reader.Close();
                return hoaDonKH;
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
        public string getSoDienThoaiDL(int maKH)
        {
            string sql =$"select SoDienThoai from KhachHang where MaKH = {maKH}" ;

            try
            {
                return MyExecuteScalar(sql, CommandType.Text).ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string getTenKhachHangDL(int maKH)
        {
            string sql = $"select TenKH from KhachHang where MaKH = {maKH}";

            try
            {
                return MyExecuteScalar(sql, CommandType.Text).ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string getDiaChiGiaoHangDL(int maDH)
        {
            string sql = $"select DiaChi from DonHang where MaDH = {maDH}";

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
