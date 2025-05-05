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
    public class ucXuatHoaDonBL
    {
        private ucXuatHoaDonDL uc_XuatHoaDonDL;
        public ucXuatHoaDonBL() 
        {
            uc_XuatHoaDonDL = new ucXuatHoaDonDL();
        }

        public List<HoaDonKH> GetHoaDonBL()
        {
            try
            {
                return uc_XuatHoaDonDL.GetHoaDonDL();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<ChiTietDonHang> GetChiTietDonHangDL(int MaDHinput)
        {
            try
            {
                return uc_XuatHoaDonDL.GetChiTietDonHangDL(MaDHinput);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HoaDonKH> timKiemHoaDonMaKHBL(int maKH)
        {
            try
            {
                return uc_XuatHoaDonDL.timKiemHoaDonMaKHDL(maKH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HoaDonKH> timKiemHoaDonSoDienThoaiBL(string soDienThoai)
        {
            try
            {
                return uc_XuatHoaDonDL.timKiemHoaDonSoDienThoaiDL(soDienThoai);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string getTenKhachHangBL(int MaKH) 
        {
            try
            {
                string tenKH = uc_XuatHoaDonDL.getTenKhachHangDL(MaKH);
                return tenKH != null ? tenKH : "null";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getSoDienThoaiBL(int MaKH)
        {
            try
            {
                string sdt = uc_XuatHoaDonDL.getSoDienThoaiDL(MaKH);
                return sdt != null ? sdt : "null";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getDiaChiGiaoHangBL(int maDH)
        {
            try
            {
                string sdt = uc_XuatHoaDonDL.getDiaChiGiaoHangDL(maDH);
                return sdt != null ? sdt : "null";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
