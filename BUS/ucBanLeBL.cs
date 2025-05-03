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
    public class ucBanLeBL
    {
        private ucBanLeDL uc_BanLeDL;
        public ucBanLeBL()
        {
            uc_BanLeDL = new ucBanLeDL();
        }
        public KhachHang timKiemKhachHangBL(string SDT) //Chưa test nha 
        {
            try
            {
                var khachHang = uc_BanLeDL.timKiemKhachHangDL(SDT);
                return khachHang != null ? khachHang : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VatLieuTonKho> GetVatLieuTonKhoBL()
        {
            try
            {
                return uc_BanLeDL.GetVatLieuTonKhoDL();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<VatLieuTonKho> timKiemSanPhamBL(string tenVLInPut)
        {
            try
            {
                return uc_BanLeDL.tinKiemSanPhamDL(tenVLInPut);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int themKhachHangBL(KhachHang kh)
        {
            try
            {
                int result = uc_BanLeDL.themKhachHangDL(kh);
                if (result < 1)
                {
                    throw new Exception("Dữ liệu không được thêm vào Database");
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string getMaKHBL(string sdt)
        {
            try
            {
                if (uc_BanLeDL.getMaKHDL(sdt) != null && uc_BanLeDL.getMaKHDL(sdt) != "")
                    return uc_BanLeDL.getMaKHDL(sdt);
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getMaNVBL(string username)
        {
            try
            {
                if (uc_BanLeDL.getMaNVDL(username) != null && uc_BanLeDL.getMaNVDL(username) != "")
                    return uc_BanLeDL.getMaNVDL(username);
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getMaVLBL(string tenVL)
        {
            try
            {
                if (uc_BanLeDL.getMaVLDL(tenVL) != null && uc_BanLeDL.getMaVLDL(tenVL) != "")
                    return uc_BanLeDL.getMaVLDL(tenVL);
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public int insertDonHangBL(DonHang donHang)
        {
            try
            {
                int result = uc_BanLeDL.insertDonHangDL(donHang);
                if (result < -1)
                {
                    throw new Exception("Dữ liệu không được thêm vào Database");
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int insertHoaDonBL(HoaDon hoaDon)
        {
            try
            {
                int result = uc_BanLeDL.insertHoaDonDL(hoaDon);
                if (result < 1)
                {
                    throw new Exception("Dữ liệu không được thêm vào Database");
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemCongNoBL(string SoDienThoai, int TienNo)
        {
            try
            {
                int result = uc_BanLeDL.ThemCongNoDL(SoDienThoai, TienNo);
                if (result < 1)
                {
                    throw new Exception("Dữ liệu không được thêm vào Database");
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemLichSuCongNoBL(LichSuCongNo lichSuCongNo)
        {
            try
            {
                int result = uc_BanLeDL.ThemLichSuCongNoDL(lichSuCongNo);
                if (result < 1)
                {
                    throw new Exception("Dữ liệu không được thêm vào Database");
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemChiTietDonHangBL(ChiTietDonHang chiTietDonHang)
        {
            try
            {
                int result = uc_BanLeDL.ThemChiTietDonHangDL(chiTietDonHang);
                if (result < 1)
                {
                    throw new Exception("Dữ liệu không được thêm vào Database");
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
