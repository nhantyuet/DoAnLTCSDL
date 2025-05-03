using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class LoginDL : DataProvider
    {
        public string CheckLoginDL(TaiKhoan taiKhoan)
        {
            string sql = "SELECT Role FROM TaiKhoan WHERE Username = '"+taiKhoan.Username+"' AND Password = '"+ taiKhoan.Password+ "'";
            try 
            {
                return MyExecuteScalar(sql,CommandType.Text).ToString();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
