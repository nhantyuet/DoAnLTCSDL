using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DTO
{
    public class FrmNhanVienDL: DataProvider
    {
        public string tenNhanVienDL (string maNV)
        {
            string sql = "select TenNV\r\nfrom NhanVien join TaiKhoan on NhanVien.MaNV = TaiKhoan.MaNV\r\nwhere Username = '" + maNV + "'";
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
