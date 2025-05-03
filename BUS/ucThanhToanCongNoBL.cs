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
    public class ucThanhToanCongNoBL
    {
        private ucThanhToanCongNoDL uc_ThanhToanCongNoDL;
        public ucThanhToanCongNoBL()
        {
            uc_ThanhToanCongNoDL = new ucThanhToanCongNoDL();
        }
        public KhachHang timKiemKhachHangBL(string SDT) //Chưa test nha 
        {
            try
            {
                var khachHang = uc_ThanhToanCongNoDL.timKiemKhachHangDL(SDT);
                return khachHang != null ? khachHang : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertLichSuCongNoBL(LichSuCongNo lichSuCongNo)
        {
            try
            {
                int result = uc_ThanhToanCongNoDL.InsertLichSuCongNoDL(lichSuCongNo);
                if (result < 0)
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
        public int UpdateCongNoKhachHangBL(string soDienThoai, int soTien)
        {

            try
            {
                int result = uc_ThanhToanCongNoDL.UpdateCongNoKhachHangDL(soDienThoai,soTien);
                if (result < 0)
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
                if (uc_ThanhToanCongNoDL.getMaKHDL(sdt) != null && uc_ThanhToanCongNoDL.getMaKHDL(sdt) != "")
                    return uc_ThanhToanCongNoDL.getMaKHDL(sdt);
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
                if (uc_ThanhToanCongNoDL.getMaNVDL(username) != null && uc_ThanhToanCongNoDL.getMaNVDL(username) != "")
                    return uc_ThanhToanCongNoDL.getMaNVDL(username);
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
