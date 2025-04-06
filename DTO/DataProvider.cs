using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DataProvider
    {
        private SqlConnection cn;

        public DataProvider()
        {
            //tren may m se khac cai snStr nen phai doi lai ten connect dc
            string cnStr = "Data Source=DESKTOP-U6OJ5V3\\MAYONHA;Initial Catalog=QuanLyKhoVLXD;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string CheckLogin(Account account)
        {
            try
            {
                Connect();
                string query = "SELECT Role FROM TaiKhoan WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Username", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.Password);

                string roled="";
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    roled = result.ToString();
                }
                Disconnect();
                if (roled != "")
                {
                    return roled;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }
    }
}
